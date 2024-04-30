using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CorridorManager : MonoBehaviour
{
    public int corridorID; // ID for this corridor
    private static int lastCorridorID = -1; // Last corridor entered
    private static List<int> currentSequence = new List<int>(); // Current sequence of player moves
    private static List<int[]> validSequences = new List<int[]> {
        new int[] {3, 4, 3, 4, 1, 2},
        new int[] {4, 1, 4, 1, 2, 3},
        new int[] {1, 2, 1, 2, 3, 4},
        new int[] {2, 3, 2, 3, 4, 1}
    }; // List of valid sequences
    public GameObject[] lights; // Light objects for feedback

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentCorridor = corridorID;
            if (lastCorridorID != currentCorridor) // Ensure different corridors
            {
                if (!ContinueSequence(currentCorridor))
                {
                    ResetSequence(currentCorridor);
                    currentSequence.Add(currentCorridor); // Start new sequence from current corridor
                    UpdateLights(0); // Light the first light as the new start
                    Debug.Log($"Starting new sequence from corridor {currentCorridor}.");
                }
                lastCorridorID = currentCorridor; // Update the last corridor entered
            }
        }
    }

    bool ContinueSequence(int currentCorridor)
    {
        currentSequence.Add(currentCorridor);
        foreach (var sequence in validSequences)
        {
            if (IsValidSequence(sequence))
            {
                UpdateLights(currentSequence.Count - 1); // Update lights up to the current valid index
                Debug.Log($"Current sequence is valid. Progress: {currentSequence.Count}/{sequence.Length}. Current Path: {string.Join(", ", currentSequence)}");
                if (currentSequence.Count == sequence.Length)
                {
                    Debug.Log("Puzzle Completed!");
                    SceneManager.LoadScene("Victory");
                }
                return true;
            }
        }
        Debug.Log($"Sequence invalid at step {currentSequence.Count}. Current Path: {string.Join(", ", currentSequence)}");
        return false;
    }

    bool IsValidSequence(int[] sequence)
    {
        if (currentSequence.Count > sequence.Length) return false;
        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (currentSequence[i] != sequence[i])
                return false;
        }
        return true;
    }

    void UpdateLights(int validSteps)
    {
        for (int i = 0; i <= validSteps; i++)
        {
            lights[i].SetActive(true);
        }
        for (int i = validSteps + 1; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
    }

    void ResetSequence(int currentCorridor)
    {
        Debug.Log($"Resetting sequence due to error or completion. Starting new sequence from corridor {currentCorridor}. Last Sequence: {string.Join(", ", currentSequence)}");
        foreach (GameObject light in lights)
            light.SetActive(false);
        currentSequence.Clear();
        lastCorridorID = currentCorridor; 
    }
}
