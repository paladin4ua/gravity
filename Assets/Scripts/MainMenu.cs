﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public int levelsCount = 16;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame 
	void Update () {
		
	}

    public void OnStartClick()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
