using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadXML : MonoBehaviour {



	// Use this for initialization
	void Start () {
        XmlReader xReader = XmlReader.Create("Assets/XML/MapLevels.xml");
        while (xReader.Read()) {
            if ((xReader.NodeType == XmlNodeType.Element) && (xReader.Name == "Level")) {
                if (xReader.HasAttributes && xReader.GetAttribute("unlocked").Equals("1")) {
                    string ButtonName = "LevelButton" + xReader.GetAttribute("number");
                    try {
                        foreach(GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {
                            if(go.name.Equals(ButtonName)) {
                                go.SetActive(true);
                                go.transform.GetChild(0).gameObject.SetActive(true);
                            }
                        }
                    }
                    catch {
                        Debug.Log(ButtonName + " doesn't exist.");
                    }
                }
                    
            }
        }
    }

    public void LoadLevel(int levelNumber) {
        SceneManager.LoadScene("Level" + levelNumber);
    }
}
