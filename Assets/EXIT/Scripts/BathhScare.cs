using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BathhScare : MonoBehaviour
{
    private AudioSource moni;
    public AudioClip suarane;

    private BoxCollider suaranef;

    public GameObject bathScare;

	// Use this for initialization
	void Start ()
    {
        moni = GetComponent<AudioSource>();
        suaranef = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            moni.PlayOneShot(suarane);

        }
    }
    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            suaranef.enabled = false;
            bathScare.SetActive(true);
        }
    }
}
