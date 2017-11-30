using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelDlg : MonoBehaviour {

    public Button nextLevelBtn;
    public Button menuBtn;
    public Text scoreFld;


    public void ShowSuccess(int score, int stars)
    {
        this.gameObject.SetActive(true);

        nextLevelBtn.gameObject.SetActive(true);
        menuBtn.gameObject.SetActive(false);

        scoreFld.text = score.ToString();
    }

    public void ShowFail()
    {
        this.gameObject.SetActive(true);

        nextLevelBtn.gameObject.SetActive(false);
        menuBtn.gameObject.SetActive(true);

        scoreFld.text = "Failed";
    }

    public void Retry()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void ShowLevelsMenu()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
