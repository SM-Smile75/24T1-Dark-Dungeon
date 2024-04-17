using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    [SerializeField]
    public Image journal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            journal.enabled = true;
        }

        if (other.CompareTag("Player"))
        {
            journal.enabled = false;
        }
    }
}
