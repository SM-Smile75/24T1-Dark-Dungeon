using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1Goals : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzle1Solved();
    }

    public Lights[] torches;
    private bool[] correctPattern = { true, false, true, false, true, false, true, true};
    public Animator doorOpen;
    int theNumber = 0;

    public void Puzzle1Solved()
    {
      for (int i = 0; i < torches.Length; i++)
      {
            if (torches[i].lightsOn == correctPattern[i])
            {
                theNumber++;
            }
            
      }
      
        if(torches.Length == theNumber)
      
        {
            doorOpen.SetTrigger("Puzzle1Solved");
      
        }

        else
        {
            theNumber = 0;
        }
    }

}
