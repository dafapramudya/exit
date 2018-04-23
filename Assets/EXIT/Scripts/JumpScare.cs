using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    private AudioSource moni;
    public AudioClip suarane;

    public BoxCollider suaranef;

    // Use this for initialization
    void Start()
    {
        moni = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moni.PlayOneShot(suarane);
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            suaranef.enabled = false;
        }
    }
}
