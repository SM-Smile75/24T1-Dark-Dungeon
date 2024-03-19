using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light candleLight;

    void Start()
    {
        candleLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            candleLight.enabled = !candleLight.enabled;
            float waitTime = Random.Range(0.5f, 2.0f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
