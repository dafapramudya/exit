using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSound : MonoBehaviour
{

    private AudioSource sources;
    public AudioClip btnSound;

    //Kita membuat 2 variabel instance ini supaya semua komponen publik yang ada di script ini bisa diakses oleh suatu script.
    private static ButtonSound instance;
    public static ButtonSound Instance { get { return instance; } }

	// Use this for initialization
	void Start ()
    {
        instance = this;
        sources = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Moni()
    {
        sources.PlayOneShot(btnSound);
    }
}
