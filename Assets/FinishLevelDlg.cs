using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelDlg : MonoBehaviour {

    public Button nextLevelBtn;
    public Button menuBtn;
    public Text scoreFld;


    public void ShowSuccess(int score)
    {
        this.gameObject.SetActive(true);

        nextLevelBtn.gameObject.SetActive(true);
        menuBtn.gameObject.SetActive(false);

        scoreFld.text = score.ToString();
    }

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
