using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        OpenDoor();
    }

    Animator animator;
    bool doorOpen;
    public GameObject theDoor;

    void Start()
    {
        doorOpen = false;
        animator = theDoor.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if(doorOpen == false)
        {
            animator.SetBool("Door Open", true);
            doorOpen = true;
        }
        else
        {
            animator.SetBool("Door Open", false);
            doorOpen = false;
        }
        

    }

}
