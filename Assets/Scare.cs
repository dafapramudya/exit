using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scare : MonoBehaviour
{
    public GameObject scaryPicture;
    public GameObject deadPanel;
    public AudioClip scareSound;
    private AudioSource scareSource;
    private BoxCollider scareCollider;
	// Use this for initialization
	void Start () {
        scareSource = GetComponent<AudioSource>();
        scareCollider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            scaryPicture.SetActive(true);
            scareSource.PlayOneShot(scareSound);
            StartCoroutine("WaitScareSound");
            Time.timeScale = 0;

        }
    }

    IEnumerator WaitScareSound()
    {
        yield return new WaitForSeconds(scareSound.length);
    }
}
