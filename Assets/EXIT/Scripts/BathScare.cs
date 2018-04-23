using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathScare : MonoBehaviour
{

    public GameObject blood;
    public GameObject deathText;
    public GameObject newEvent;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            blood.SetActive(true);
            deathText.SetActive(true);
            newEvent.SetActive(true);
        }
    }
}
