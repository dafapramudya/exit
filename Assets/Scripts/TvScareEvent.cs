using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class TvScareEvent : MonoBehaviour {

	public Texture2D noiseTexture;
	public Texture2D scareTexture;
	public AudioClip noiseSound;
	public AudioClip scareSound;
	public float scareTime = 3f;
    AudioSource audio;
	
	bool showScare = false; //private bool showscare
	
    void Start()
    {

    }

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			GetComponent<Renderer>().material.mainTexture = scareTexture;
			audio.Stop();
			audio.loop = false;
			audio.clip = scareSound;
			audio.Play();
			
			showScare = true;
		}
	}
	
	void Update () 
	{
		if(showScare)
		{
			scareTime -= Time.deltaTime;
			if(scareTime <= 0)
			{
				GetComponent<Renderer>().material.mainTexture = noiseTexture;
				audio.Stop();
				audio.loop = true;
				audio.clip = noiseSound;
				audio.Play();
				
				showScare = false;
			}
		}
	}
}
