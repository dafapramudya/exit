using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public BoxCollider bC;
    public DoorScript door3;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(door3.open == true)
            {
                if(door3.open == false)
                {
                    Debug.Log("Pintu terkunci!");
                }
            }
        }
    }
}
