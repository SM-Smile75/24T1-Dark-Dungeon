using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject journalBook;
    public GameObject cursorPoint;
    public GameObject player;
    public GameObject camPlayer;

    void Start()
    {
        pauseMenu.SetActive(false);
        journalBook.SetActive(false);

    }

    public void TextBoxStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camPlayer.GetComponent<PlayerCam>().enabled = true;
        cursorPoint.SetActive(false);
        player.SetActive(false);

    }

    public void ReadyToMove() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camPlayer.GetComponent<PlayerCam>().enabled = false;
        cursorPoint.SetActive(false);
        player.SetActive(false);
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camPlayer.GetComponent<PlayerCam>().enabled = false;
        pauseMenu.SetActive(true);
        cursorPoint.SetActive(false);
        player.SetActive(false);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camPlayer.GetComponent<PlayerCam>().enabled = true;
        pauseMenu.SetActive(false);
        journalBook.SetActive(false);
        cursorPoint.SetActive(true);
        player.SetActive(true);
        Time.timeScale = 1;

    }
    public void JournalBook()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camPlayer.GetComponent<PlayerCam>().enabled = false;
        cursorPoint.SetActive(false);
        journalBook.SetActive(true);
        player.SetActive(false);
        Time.timeScale = 1;

    }


    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            journalBook.SetActive(false);
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            ContinueGame();
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
