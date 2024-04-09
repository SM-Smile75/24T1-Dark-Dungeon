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
    public Transform InteractSource;
    public float InteractRange;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractSource.position, InteractSource.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}