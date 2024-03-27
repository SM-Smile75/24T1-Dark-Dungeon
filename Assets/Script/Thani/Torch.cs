using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, Usable
{
    bool isOn;
    public GameObject flame;

    public void Use()
    {
        if(isOn == true)
        {
            isOn = false;
            flame.SetActive(false);
        }

        if (isOn == false)
        {
            isOn = true;
            flame.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
