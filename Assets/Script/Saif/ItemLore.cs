using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLore : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        ItemTextBox();
    }

    public GameObject loreTextBox;
    PlayerUI thePlayer;

    void Start()
    {
        loreTextBox.SetActive(false);
    }
    public void ItemTextBox()
    {
        thePlayer = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        loreTextBox.SetActive(true);
        thePlayer.TextBoxStart();

    }
    public void CloseItemTextBox()
    {
        loreTextBox.SetActive(false);
        thePlayer.ContinueGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && loreTextBox.activeSelf)
        {
            CloseItemTextBox();
        }
    }
}
