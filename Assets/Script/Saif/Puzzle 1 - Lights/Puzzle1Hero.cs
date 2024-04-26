using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Hero : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ReadStory();
    }

    public GameObject stonePlank;
    public GameObject player;
    public GameObject camPlayer;
    //bool hide = false;

    void Start()
    {
        stonePlank.SetActive(false);

    }

    public void ReadStory()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camPlayer.GetComponent<PlayerCam>().enabled = false;
        stonePlank.SetActive(true);
        player.SetActive(false);

    }
    public void StoryClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camPlayer.GetComponent<PlayerCam>().enabled = true;
        stonePlank.SetActive(false);
        player.SetActive(true);

    }

}
