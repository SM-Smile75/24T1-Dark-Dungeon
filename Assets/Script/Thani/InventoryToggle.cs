using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    bool isOn;
    public GameObject inventory;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (isOn == false)
            {
                isOn = true;
                inventory.SetActive(true);
                Time.timeScale = 0.0f;
            } else if (isOn == true)
            {
                isOn = false;
                inventory.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

}
