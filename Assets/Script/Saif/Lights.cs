using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ChangeLights();
    }

    public GameObject lights;
    public bool lightsOn = false;

    public void ChangeLights()
    {
        if (lightsOn == false)
        {
            lights.SetActive(false);
            lightsOn = true;
        }
        else
        {
            lights.SetActive(true);
            lightsOn = false;
        }
    }

}
