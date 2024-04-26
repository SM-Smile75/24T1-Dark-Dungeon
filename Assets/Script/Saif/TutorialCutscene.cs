using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCutscene : MonoBehaviour
{

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial Level");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Tutorial Level");
        }
    }
}
