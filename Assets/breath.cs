using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breath : MonoBehaviour {

    public AudioClip breathh;
    private BoxCollider areaaaa;
    public GameObject objScare;
    private AudioSource breathSource;

	// Use this for initialization
	void Start () {
        breathSource = GetComponent<AudioSource>();
        areaaaa = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            breathSource.PlayOneShot(breathh);
        }
    }
    void OnTriggerExit(Collider otther)
    {
        if(otther.gameObject.tag == "Player")
        {
            areaaaa.enabled = false;
            objScare.SetActive(true);
        }
    }
}
