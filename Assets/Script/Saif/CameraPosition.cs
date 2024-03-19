using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform theCamera;

    private void Update()
    {
        transform.position = theCamera.position;
    }
}
