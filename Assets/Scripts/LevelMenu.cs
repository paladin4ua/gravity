﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {




     List<LevelInfo> loadLevelsInfo()
     {
        return JsonUtility.FromJson<List<LevelInfo>>(levelsInfo.text);
     }



    private static string[] levels = { "demoScene", "demoScene", "demoScene", "demoScene", "demoScene", "demoScene", "demoScene", "demoScene", "demoScene", "demoScene", "demoScene" , "demoScene" };

    public Button buttonTmpl;

    public GameObject layout;
    public TextAsset levelsInfo;    

    // Use this for initialization
    void Start ()
    {		
        foreach(string level in levels)
        {
            var obj = (GameObject)Instantiate(buttonTmpl.gameObject, layout.transform);
            obj.GetComponent<Button>().onClick.AddListener( () => SceneManager.LoadScene(level, LoadSceneMode.Single));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
