using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleController : MonoBehaviour
{
    public Torch1[] torches;
    private bool[] correctPattern = { true, false, true, true, false, true };
    public GameObject door;
    public AudioSource puzzleCompleteSound;
    public string nextSceneName;
    public void CheckPuzzle()
    {
        for (int i = 0; i < torches.Length; i++)
        {
            if (torches[i].isLit != correctPattern[i])
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