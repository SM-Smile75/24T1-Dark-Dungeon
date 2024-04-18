using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject journalBook;
    public GameObject player;
    public GameObject camPlayer;

    void Start()
    {
        pauseMenu.SetActive(false);
        journalBook.SetActive(false);

    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camPlayer.GetComponent<PlayerCam>().enabled = false;
        pauseMenu.SetActive(true);
        player.SetActive(false);
    }
    public void ContinueGame()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camPlayer.GetComponent<PlayerCam>().enabled = true;
        pauseMenu.SetActive(false);
        journalBook.SetActive(false);
        player.SetActive(true);

    }
    public void JournalBook()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        camPlayer.GetComponent<PlayerCam>().enabled = false;
        journalBook.SetActive(true);
        player.SetActive(false);

    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            journalBook.SetActive(false);
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Tab) && !journalBook.activeSelf)
        {
            pauseMenu.SetActive(false);
            JournalBook();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && journalBook.activeSelf)
        {
            ContinueGame();
        }
    }
}
