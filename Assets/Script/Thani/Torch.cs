using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, Clickable
{
    bool isOn;
    public GameObject flame;

    public void Click()
    {
        if(isOn == true)
        {
            isOn = false;
            flame.SetActive(false);

        } else if (isOn == false)
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
