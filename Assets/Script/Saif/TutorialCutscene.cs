using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCutscene : MonoBehaviour
{

    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("Tutorial Level", LoadSceneMode.Single);
    }

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
