using UnityEngine;
using System.Collections.Generic;

public class CorridorManager : MonoBehaviour
{
    public int corridorID; // ID for this corridor
    private static int lastCorridorID = -1; // Last corridor entered
    private static List<int> currentSequence = new List<int>(); 
    private static List<int[]> validSequences = new List<int[]> {
        new int[] {3, 4, 3, 4, 1, 2}, // Original sequence
        new int[] {4, 1, 4, 1, 2, 3}, // All other possible sequences
        new int[] {1, 2, 1, 2, 3, 4},
        new int[] {2, 3, 2, 3, 4, 1},
        
    };
    public GameObject[] lights; // Light objects for feedback

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentCorridor = corridorID;
            if (lastCorridorID != -1 && lastCorridorID != currentCorridor)
            {
                currentSequence.Add(currentCorridor);
                CheckSequence();
            }
            lastCorridorID = currentCorridor;
        }
    }

    void CheckSequence()
    {
        bool isValid = false;
        int validLength = 0;
        foreach (var sequence in validSequences)
        {
            int matchedLength = GetMatchedSequenceLength(sequence);
            if (matchedLength > validLength)
            {
                validLength = matchedLength;
                isValid = true;
            }
        }

        UpdateLights(validLength - 1); // Update lights :D

        if (isValid && validLength == validSequences[0].Length)
        {
            Debug.Log("Puzzle Completed!");
            ResetSequence();
        }
        else if (!isValid)
        {
            ResetSequence();
        }
    }

    int GetMatchedSequenceLength(int[] sequence)
    {
        int matchCount = 0;
        for (int i = 0; i < currentSequence.Count && i < sequence.Length; i++)
        {
            if (currentSequence[i] == sequence[i])
                matchCount++;
            else
                break;
        }
        return matchCount;
    }

    void UpdateLights(int step)
    {
        for (int i = 0; i <= step; i++)
        {
            lights[i].SetActive(true); // Activate lights till the current one
        }
        for (int i = step + 1; i < lights.Length; i++)
        {
            lights[i].SetActive(false); // Deactivate all other lights
        }
    }

    void ResetSequence()
    {
        foreach (GameObject light in lights)
            light.SetActive(false); // Turn off all lights
        currentSequence.Clear();
        currentSequence.Add(corridorID); // Start new sequence from current corridor
        lights[0].SetActive(true); 
    }
}
