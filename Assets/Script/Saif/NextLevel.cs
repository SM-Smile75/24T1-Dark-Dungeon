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
    PlayerUI thePlayer;

    void Start()
    {
        thePlayer = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
    }
    public void ReadyToExplore()
    {
        readyBox.SetActive(true);
        thePlayer.ReadyToMove();
    }

    public void NotReady()
    {
        readyBox.SetActive(false);
        thePlayer.ContinueGame();
    }
   
}
