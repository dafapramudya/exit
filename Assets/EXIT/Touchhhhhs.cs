using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchhhhhs : MonoBehaviour
{
    public GameObject projectile;
    public GameObject clone;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(1).phase == TouchPhase.Began)
            {
                clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            }
        }
	}
}
