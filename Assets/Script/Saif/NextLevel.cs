using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ReadyToExplore();
    }
    public GameObject readyBox;
    public GameObject notReadyBox;
    public GameObject theJournal;
    PlayerUI thePlayer;

    void Start()
    {
        thePlayer = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        notReadyBox.SetActive(false);
    }
    public void ReadyToExplore()
    {
        if (theJournal.activeSelf)
        {
            notReadyBox.SetActive(true);
            thePlayer.TextBoxStart();
        }
        else { 
        readyBox.SetActive(true);
        thePlayer.ReadyToMove();
    
        }
    }
    public void NotReady()
    {
        notReadyBox.SetActive(false);
        readyBox.SetActive(false);
        thePlayer.ContinueGame();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && notReadyBox.activeSelf)
        {
            NotReady();
        }
    }
}
