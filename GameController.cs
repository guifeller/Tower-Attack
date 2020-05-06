using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

    
    
    public int yokaiLeft;

    public GameObject victoryMenu;
    public TextMeshProUGUI scoreText, finalScoreText;
    public int levelNumber, sceneOffset = 2;
    public int score;
    public int yokaiObjective, buildingObjective;
    public static GameController instance = null;

    private int minutes, seconds, timer;
    private int yokaiArrived, turretDestroyed;
    private bool yokaiObjectiveAchieved = false, buildingObjectiveAchieved = false;


    private void Awake() {

        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        victoryMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    void SetTimer() {
        timer += Mathf.FloorToInt(Time.deltaTime);
        minutes = timer / 60;
        seconds = timer % 60;
    }

    public int ReturnMinute() {
        return minutes;
    }

    public int ReturnSeconds() {
        return seconds;
    }

    public void UpdateScore(GameObject gObj) {
        score += gObj.GetComponent<ValueTable>().ScoreValue;
        scoreText.text = score.ToString() + " points"; 
        finalScoreText.text = score.ToString() + " points";
    }

    public int ReturnScore() {
        return score;
    }

    public void UpdateArrivedYokai() {
        yokaiArrived++;
    }

    public void YokaiDead() {
        yokaiLeft--;
    }

    public void CheckObjective() {
        if (yokaiArrived >= yokaiObjective) {
            yokaiObjectiveAchieved = true;
        }

        if (turretDestroyed >= buildingObjective) {
            buildingObjectiveAchieved = true;
        }

        if (yokaiLeft <= 0 && (!yokaiObjectiveAchieved || !buildingObjectiveAchieved)) {
            GameOver();
        }

        else if (yokaiObjectiveAchieved && buildingObjectiveAchieved) {
            Victory();
        }
    }

    public void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        
    }

    public void TurretDestroyed() {
        buildingObjective++;
        CheckObjective();
    }

    public void Victory() {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Assets/XML/MapLevels.xml");
        XmlNodeList userNodes = xmlDoc.SelectNodes("//Levels/Level");
        foreach (XmlNode userNode in userNodes) {
            if (userNode.Attributes["number"].Value.Equals(levelNumber.ToString())) {
                int unlocked = int.Parse(userNode.Attributes["unlocked"].Value);
                if(score > int.Parse(userNode.Attributes["score"].Value)) {
                    userNode.Attributes["score"].Value = score.ToString();
                }
                userNode.Attributes["unlocked"].Value = "1";
            }
        }
        xmlDoc.Save("Assets/XML/MapLevels.xml");
        
        victoryMenu.SetActive(true);
        scoreText.gameObject.SetActive(false);
        Debug.Log("You Won!");
    }

    
}
