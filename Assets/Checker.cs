using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour {

    public GameObject cekScare;
    private BoxCollider kieh;
	// Use this for initialization
	void Start () {
        kieh = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cekScare.SetActive(true);
            kieh.enabled = false;
        }
    }
}
