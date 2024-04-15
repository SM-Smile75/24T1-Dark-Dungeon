using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleController : MonoBehaviour
{
    public Lights[] torches;
    private bool[] correctPattern = { true, false, true, false, true, false, true, false};
    public GameObject door;
    public AudioSource puzzleCompleteSound;
    public string nextSceneName;
    public void CheckPuzzle()
    {
        for (int i = 0; i < torches.Length; i++)
        {
            if (torches[i].lightsOn != correctPattern[i])
                return;
        }
        PuzzleSolved();
    }

    void PuzzleSolved()
    {
        door.SetActive(false); 
       
            puzzleCompleteSound.Play(); 
        
        Invoke("LoadNextScene", 10f);    }

void LoadNextScene()
{
    SceneManager.LoadScene(nextSceneName); 
}
}