using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBox : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        OpenBox();
    }

    public GameObject gearText;
    Animator animator;
    bool boxOpen;
    public GameObject theBox;
    int activeOnce;
    PlayerUI thePlayer;

    void Start()
    {
        thePlayer = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        boxOpen = false;
        animator = theBox.GetComponent<Animator>();
        gearText.SetActive(false);
        activeOnce = 0;
    }

    public void OpenBox()
    {
        if (boxOpen == false)
        {
            animator.SetBool("Box Open", true);
            boxOpen = true;
            if (activeOnce == 0)
            {
                thePlayer.TextBoxStart();
                gearText.SetActive(true);
                activeOnce++;
            }
            
        }
        else
        {
            animator.SetBool("Box Open", false);
            boxOpen = false;
        }
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gearText.activeSelf)
        {
            gearText.SetActive(false);
            thePlayer.ContinueGame();
        }
    }
}
