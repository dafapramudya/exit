using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public DoorScript myDoor;
    public AudioClip pickupSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void UnlockDoor()
    {
        myDoor.isLocked = false;
        audioSource.PlayOneShot(pickupSound);

        StartCoroutine("WaitForSelfDestruct");
    }

    IEnumerator WaitForSelfDestruct()
    {
        yield return new WaitForSeconds(pickupSound.length);
        Destroy(gameObject);
    }
}
