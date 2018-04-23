using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    private Light flashLight;
    private AudioSource audioSource;

    public AudioClip soundFlashlightOn;
    public AudioClip soundFlashlightOff;

    private static Flashlight instance;
    public static Flashlight Instance { get { return instance; } }

    private bool isActive;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        flashLight = GetComponent<Light>();
        instance = this;
        isActive = true;
	}
	
	// Update is called once per frame
    // Use this for Input
	void Update ()
    {
	    
	}

    public void MatiMurub()
    {
        flashLight.enabled = true;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isActive == false) //Toggle Flashlight On
            {
                flashLight.enabled = true;
                isActive = true;

                audioSource.PlayOneShot(soundFlashlightOn);
            }
            else if (isActive == true) //Toggle Flashlight Off
            {
                flashLight.enabled = false;
                isActive = false;

                audioSource.PlayOneShot(soundFlashlightOff);
            }
        }
    }
}
