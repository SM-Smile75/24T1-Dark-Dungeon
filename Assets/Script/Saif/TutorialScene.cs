using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{

    public GameObject[] textBox;
    PlayerUI thePlayer;
    
    void Start()
    {
        if(textBox.Length <= 1) 
        {
            textBox[0].SetActive(false);
        }
        else { 
        thePlayer = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        textBox[0].SetActive(true);
        thePlayer.TextBoxStart();
        }
    }

    public void CloseTextBox()
    {

        if (textBox[0].activeSelf && !textBox[1].activeSelf)
        {
            textBox[0].SetActive(false);
            textBox[1].SetActive(true);
        }

        else
        { 

            for (int i = 0; i < textBox.Length; i++)
            {
                if (textBox[i].activeSelf)
                {
                    textBox[i].SetActive(false);
                    thePlayer.ContinueGame();
                    i = 0;

                }
                
            }
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            CloseTextBox();
        }


    }
}
