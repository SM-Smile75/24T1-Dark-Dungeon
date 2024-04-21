using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact();
}

public class Interact : MonoBehaviour
{
    public GameObject cursorPointer;
    public GameObject cursorInteract;
    public Transform InteractSource;
    public float InteractRange;

    void Start()
    {
        cursorPointer.SetActive(true);
        cursorInteract.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(InteractSource.position, InteractSource.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {

            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                cursorPointer.SetActive(false);
                cursorInteract.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                }

            }
        }
        else
        {
            cursorPointer.SetActive(true);
            cursorInteract.SetActive(false);
        }

    }
}