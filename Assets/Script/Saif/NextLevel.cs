using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
    public PlayableDirector sceneTransition;

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
    public void CustscenePlay()
    {
        notReadyBox.SetActive(false);
        readyBox.SetActive(false);
        sceneTransition.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && notReadyBox.activeSelf)
        {
            NotReady();
        }
    }
}
