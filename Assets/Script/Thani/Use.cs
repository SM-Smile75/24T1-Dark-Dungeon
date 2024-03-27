using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
interface Usable
{
    public void Use();
}

public class Use : MonoBehaviour
{
    public Transform source;
    public float range;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Ray ray = new Ray(source.position, source.forward);
            {
                if(Physics.Raycast(ray, out RaycastHit hitInfo, range))
                {
                    if(hitInfo.collider.gameObject.TryGetComponent(out Usable usableObject))
                    {
                        usableObject.Use();
                    }
                }
            }
        }
    }
}
