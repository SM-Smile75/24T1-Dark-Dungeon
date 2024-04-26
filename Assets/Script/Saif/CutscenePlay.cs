using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlay : MonoBehaviour
{
    public GameObject player;
    public GameObject playerUI;
    public void PlayCutscene()
    {
        player.SetActive(false);
        playerUI.SetActive(false);
    }

    public void StopCutscene()
    {
        player.SetActive(true);
        playerUI.SetActive(true);
    }

}
