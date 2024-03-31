using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager;
interface Clickable
{
    public void Click();
}

public class Click : MonoBehaviour
{
    public GameObject clickObject;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(clickObject == getClickedObject(out RaycastHit hit))
            {
                print("Clicked!");
                if (hit.collider.gameObject.TryGetComponent(out Clickable clickableObject))
                {
                    clickableObject.Click();
                    Debug.Log("Using Object...");
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            print("No longer clicked!");
        }
    }

    GameObject getClickedObject (out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }
        }
        return target;
    }

    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
