using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    bool isOn;
    public GameObject inventory;

    public void Use()
    {
        if (isOn == true)
        {
            isOn = false;
            inventory.SetActive(false);
        }

        if (isOn == false)
        {
            isOn = true;
            inventory.SetActive(true);
        }
    }
}
