using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheJournal : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GetJournal();
    }

    public GameObject journalText;
    public GameObject theJournal;
    public GameObject playerJournal;
    Collider journalCollider;
    PlayerUI thePlayer;

    void Start()
    {
        journalCollider = GetComponent<Collider>();
        thePlayer = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        playerJournal.SetActive(false);
        journalText.SetActive(false);
        theJournal.SetActive(true);
    }

    public void GetJournal()
    {
        playerJournal.SetActive(true);      
        journalText.SetActive(true);
        theJournal.SetActive(false);
        thePlayer.TextBoxStart();

    }
    public void JournalPicked()
    {
        thePlayer.ContinueGame();
        journalText.SetActive(false);
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && journalText.activeSelf)
        {
            journalCollider.enabled = false;
            JournalPicked();
        }
    }
}
