using UnityEngine;
using System.Collections;

public class DoorFinal : MonoBehaviour
{
    public bool open = false; //Is for saving the door state
    private bool hasOpenedCompletly;

    private static DoorFinal instance;
    public static DoorFinal Instance { get { return instance; } }

    public float doorOpenAngle = 90f;
    public float doorClosedAngle = 0f;

    public float smooth = 2f; //This is the speed of the rotation

    private AudioSource audioSource;
    public AudioClip openingSound;

    public GameObject canvasFinal;

    public AudioClip lockedDoorSound;

    public bool isLocked = false;

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void BukakLawang()
    {
        if (isLocked != true)//Jika isLocked false
        {
            open = !open;//open = true

            if (audioSource != null)
            {
                audioSource.PlayOneShot(openingSound);
            }
        }
        else
        {
            canvasFinal.SetActive(true);
            Time.timeScale = 0;
            PlayLockedDoorSound();
        }

    }

    void PlayLockedDoorSound()
    {
        audioSource.PlayOneShot(lockedDoorSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

            if (transform.localRotation == targetRotationOpen)
            {
                hasOpenedCompletly = true;
            }

        }
        else
        {
            Quaternion targetRotationClosed = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
            hasOpenedCompletly = false;
        }
    }
}
