﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour {

    public float velocity = 1;    


    private Attractor[] attractors = null;
    private Projectile projectile = null;
    private Rigidbody2D projectileRB = null;
    private Gate gate = null;
    private FinishLevelDlg finishLevelDlg = null;
    private LevelUI levelUI = null;

    bool startFlight = false;

    bool disableClicks = false;

    float score = 0.0f;
        
    

    void OnMouseDown()
    {
        if (disableClicks)
        {
            return;
        }

        var clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);       


        projectileRB.velocity = (new Vector2(clickPoint.origin.x, clickPoint.origin.y ) - (Vector2)projectileRB.transform.position) * velocity;
        
        startFlight = true;
        disableClicks = true;
    }    

    T LoadSingleObject<T>()
    {
        var objects = Resources.FindObjectsOfTypeAll(typeof(T)) as T[];

        Debug.Assert(objects.Length == 1, "On scene should be exactly one " + typeof(T).Name);

        return objects[0];
    }

    
    void Start () {

        attractors = FindObjectsOfType(typeof(Attractor)) as Attractor[];
        projectile = LoadSingleObject<Projectile>();
        projectileRB = projectile.GetComponent<Rigidbody2D>();
        Debug.Assert(projectileRB != null, "Projective should have Rigidbody2D component attached");

        gate = LoadSingleObject<Gate>();
        gate.parentScene = this;

        finishLevelDlg = LoadSingleObject<FinishLevelDlg>();

        levelUI = LoadSingleObject<LevelUI>();

    }
	
	
	void FixedUpdate () {
		if (startFlight)
        {

            var force = new Vector2(0, 0);

            foreach(Attractor attractor in attractors)
            {
                var r = ((Vector2)projectile.transform.position - (Vector2)attractor.transform.position);
                var magnitude = r.magnitude;

                force += attractor.charge * projectile.charge / (magnitude * magnitude * magnitude) * r;
            }

            projectileRB.AddForce(force);
            var position = projectileRB.transform.position;

            score += (projectileRB.velocity * Time.deltaTime).magnitude;
            levelUI.SetScore(Mathf.RoundToInt(score));

            if (Mathf.Abs(position.y) > 6 || Mathf.Abs(position.y) > 12)
            {
                startFlight = false;
                projectileRB.simulated = false;
                finishLevelDlg.ShowFail();
            }


        }
	}

    public void CompleateLevel(int stars)
    {
        startFlight = false;
        projectileRB.simulated = false;
        finishLevelDlg.ShowSuccess(Mathf.RoundToInt(score), stars);   
    }
}
