using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathSuara : MonoBehaviour
{

    public AudioClip suara;
    private BoxCollider refeer;

    private AudioSource source;
	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
        refeer = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            source.PlayOneShot(suara);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            refeer.enabled = false;
        }
    }
}
