using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {


    public GameScene parentScene = null;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Projectile>() == null)
        {
            return;
        }

        var projectiveCenter = other.bounds.center;
        var centerInLocal = transform.worldToLocalMatrix * new Vector4(projectiveCenter.x, projectiveCenter.y, projectiveCenter.z, 1.0f);

        var centerDistance = Mathf.Abs(centerInLocal.y);

        int score = 1;
        if (centerDistance < 0.333)
        {
            score = 3;
        }
        if (centerDistance < 0.667)
        {
            score = 2;
        }

        parentScene.CompleateLevel(score);
    }
    
}

