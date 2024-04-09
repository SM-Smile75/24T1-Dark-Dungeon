using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseScreen;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused == false)
            {
                isPaused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else if (isPaused == true)
            {
                isPaused = false;
                pauseScreen.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
}
