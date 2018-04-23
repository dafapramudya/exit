using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senter : MonoBehaviour
{

    private AudioSource audioku;
    public AudioClip njupukSenter;

	// Use this for initialization
	void Start ()
    {
        audioku = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AmbilSenter()
    {
        audioku.PlayOneShot(njupukSenter);

        Destroy(gameObject);

        Flashlight.Instance.MatiMurub();
    }
}
