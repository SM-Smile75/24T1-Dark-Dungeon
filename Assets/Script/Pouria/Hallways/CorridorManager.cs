using UnityEngine;

public class CorridorManager : MonoBehaviour
{
    public int corridorID; 

    // Keeps track of the last corridor the player was in.
    private static int lastCorridorID = -1;

    
    private static int[,] sequence = { {3, 4}, {4, 3}, {3, 4}, {4, 1}, {1, 2} };
    // Tracks the current step in the sequence
    private static int currentStep = 0;

    
    public GameObject[] lights;

    void OnTriggerEnter(Collider other)
    {
        // Detect when the player enters a corridor.
        if (other.CompareTag("Player"))
        {
            if (lastCorridorID != -1)
            {
                CheckTransition(lastCorridorID, corridorID);
            }
            lastCorridorID = corridorID;
        }
    }

    void CheckTransition(int from, int to)
    {
        
        if (from == sequence[currentStep, 0] && to == sequence[currentStep, 1])
        {
            lights[currentStep].SetActive(true);
            currentStep++;
            if (currentStep == sequence.GetLength(0))
            {
                Debug.Log("Puzzle Completed!");
            }
        }
        else
        {
            ResetSequence();
        }
    }

    void ResetSequence()
    {
        // Reset the sequence and turn off all lights.
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
        currentStep = 0;
        lastCorridorID = -1;
    }
}
