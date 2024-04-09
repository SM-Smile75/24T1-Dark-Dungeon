using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Level 1 copy");
    }
}
