using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour {

    public float velocity = 1;    


    private Attractor[] attractors = null;
    private Projectile projectile = null;
    private Rigidbody2D projectileRB = null;
    private Gate gate = null;

    bool startFlight = false;

        
    

    void OnMouseDown()
    {
        var clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);       


        projectileRB.velocity = (new Vector2(clickPoint.origin.x, clickPoint.origin.y ) - (Vector2)projectileRB.transform.position) * velocity;
        
        startFlight = true;
    }    

    T LoadSingleObject<T>()
    {
        var objects = FindObjectsOfType(typeof(T)) as T[];

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
        }
	}

    public void CompleateLevel(int score)
    {

    }
}
