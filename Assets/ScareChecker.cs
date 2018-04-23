using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareChecker : MonoBehaviour
{
    public DoorScript doorChecker;
    private AudioSource auSource;
    private BoxCollider areaScareChecker;
    public AudioClip introScare;
    public Light senterPlayer;
    public GameObject objBreath;

    // Use this for initialization
    void Start ()
    {
        areaScareChecker = GetComponent<BoxCollider>();
        auSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider user)
    {
        if(user.gameObject.tag == "Player")
        {
            if (doorChecker.open == false)
            {
                auSource.PlayOneShot(introScare);
                StartCoroutine("WaitIntroScareSound");
                senterPlayer.enabled = false;
                objBreath.SetActive(true);
                areaScareChecker.enabled = false;
            }
            else
            {
                Debug.Log("Hanya sebuah log yang muncul dalam layar");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(doorChecker.open == false)
            {
                doorChecker.isLocked = true;
            }
        }
    }

    IEnumerator WaitIntroScareSound()
    {
        yield return new WaitForSeconds(introScare.length);
    }
}
