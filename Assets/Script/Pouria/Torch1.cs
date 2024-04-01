using UnityEngine;

public class Torch1 : MonoBehaviour
{
    public bool isLit = false;
    

    public void ToggleState()
    {
        isLit = !isLit;
        gameObject.SetActive(isLit);
        FindObjectOfType<PuzzleController>().CheckPuzzle();

    }
}