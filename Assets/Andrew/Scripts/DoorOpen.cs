using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] bool isCollected;

    public Animator doorAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        isCollected = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollected = true;
            doorAnimator.SetBool("isCollected", isCollected);
        }
    }
}
