using UnityEngine;

public class DelayedAppearance : MonoBehaviour
{
    public GameObject objectToAppear; 
    public float delay = 2.0f; 

    void Start()
    {
       
        if (objectToAppear != null)
            objectToAppear.SetActive(false);

        
        Invoke(nameof(MakeObjectAppear), delay);
    }

    void MakeObjectAppear()
    {
        
        if (objectToAppear != null)
            objectToAppear.SetActive(true);
    }
}