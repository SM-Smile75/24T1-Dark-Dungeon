using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1Complete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene("Level 2");
    }
}