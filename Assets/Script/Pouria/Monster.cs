using UnityEngine;

public class Monster : MonoBehaviour
{
    public Behaviour componentToEnable; 

    void Start()
    {
        componentToEnable.enabled = false; 
        Invoke("EnableComponent", 120f);
    }

    void EnableComponent()
    {
        componentToEnable.enabled = true; 
        Debug.Log("Component enabled after 2 minutes.");
    }
}