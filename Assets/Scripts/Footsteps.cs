using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Footsteps : MonoBehaviour
{

    CharacterController charControl;
    AudioSource myAudio;
	
	void Start ()	
 	{
        myAudio = GetComponent<AudioSource>();
		charControl = GetComponent<CharacterController>();
	}
	
	void Update ()	
 	{
		if(charControl.isGrounded == true && charControl.velocity.magnitude > 2f && myAudio.isPlaying == false)
		{
			myAudio.volume = Random.Range(0.8f, 1);
			myAudio.pitch = Random.Range(0.8f, 1.1f);
			myAudio.Play();
		}
	}
}
