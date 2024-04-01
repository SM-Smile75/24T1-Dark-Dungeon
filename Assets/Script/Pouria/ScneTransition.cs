using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneTransition : MonoBehaviour
{
    public string sceneNameToLoad; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(sceneNameToLoad); 
        }
    }
}