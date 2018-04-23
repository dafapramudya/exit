using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFinish : MonoBehaviour
{
    public AudioClip soundFin;
    private AudioSource sourceFin;

	// Use this for initialization
	void Start ()
    {
        sourceFin = GetComponent<AudioSource>();
        sourceFin.PlayOneShot(soundFin);
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
