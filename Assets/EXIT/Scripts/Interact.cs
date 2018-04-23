using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{

    //public float interactDistance = 1.0f;
    public LayerMask interactLayer; //Filter

    public Image interactIcon; // Picture to show if you can interact or not

    private static Interact instance;
    public static Interact Instance { get {return instance; } }

    public bool isInteracting;

	// Use this for initialization
	void Start ()
    {
        instance = this;
        //Set Interact icon to be invisible
        if(interactIcon != null)
        {
            interactIcon.enabled = false;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Ray adalah sebuah garis lurus yang memiliki panjang tak terhingga dari original position menuju ke directional position. misal Ray coba = new Ray(transform.position(posisi awal/default objek), transform.forward(ray mengarah ke depan));
        //atau bisa dibilang ray adalah suatu komponen yang berisi original position(start posisi) dan direction(arah)
        Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit berfungsi untuk memberikan informasi tentang hit collider, seperti distance, point(poin akhir) dll.
        RaycastHit hit;

        //Shoots a ray
        if(Physics.Raycast(ray, out hit, 1, interactLayer))
        {
            //Checks if we are not interacting
            if(isInteracting == false)
            {
                if(interactIcon != null)
                {
                    interactIcon.enabled = true;
                }

                //If we press the interaction button
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //If it is a door
                    if(hit.collider.CompareTag("Door"))
                    {
                        //Open/Close it
                        hit.collider.GetComponent<DoorScript>().ChangeDoorState();
                    }
                    else if (hit.collider.CompareTag("Key"))
                    {
                        hit.collider.GetComponent<Key>().UnlockDoor();
                    }
                    else if (hit.collider.CompareTag("Senter"))
                    {
                        hit.collider.GetComponent<senter>().AmbilSenter();
                    }
                    else if (hit.collider.CompareTag("Doorbank"))
                    {
                        hit.collider.GetComponent<DoorBank>().MbukakLawang();
                    }
                    else if (hit.collider.CompareTag("FinalDoor"))
                    {
                        hit.collider.GetComponent<DoorFinal>().BukakLawang();
                    }
                    //else if (hit.collider.CompareTag("Safe"))
                    //{
                    //    hit.collider.GetComponent<Safe>().ShowSafeCanvas();
                    //}
                    //else if(hit.collider.CompareTag("Note"))
                    //{
                    //    hit.collider.GetComponent<Note>().ShowNoteImage();
                    //}
                    //else if(hit.collider.CompareTag("Pistol"))
                    //{
                    //    hit.collider.GetComponent<PistolPickup>().PickupPistol();
                    //}
                }
            }
        }
        else
        {
            interactIcon.enabled = false;
        }
	}
}
