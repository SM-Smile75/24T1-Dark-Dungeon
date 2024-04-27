using UnityEngine;
using System.Collections.Generic;

public class CorridorManager : MonoBehaviour
{
    public int corridorID; // Unique ID for each corridor, set this in the Unity inspector.
    private static int lastCorridorID = -1; // Keeps track of the last corridor ID entered.
    private static List<int> currentSequence = new List<int>(); // Current sequence of corridor IDs.
    private static int[] requiredSequence = {3, 4, 3, 4, 1, 2}; // This is the base pattern adjusted to all possible starts.
    public GameObject[] lights; // Assign corresponding lights in the inspector for feedback.

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentCorridor = corridorID;
            // Prevent the same corridor from being processed consecutively
            if (lastCorridorID != currentCorridor)
            {
                ProcessEntry(currentCorridor);
                lastCorridorID = currentCorridor; // Update the last corridor ID
            }
        }
    }

    void ProcessEntry(int currentCorridor)
    {
        currentSequence.Add(currentCorridor);
        Debug.Log($"Entered Corridor: {currentCorridor}. Current Sequence: {string.Join(", ", currentSequence)}");
        int correctSteps = ValidateSequence();

        // Update lights based on correct steps
        UpdateLights(correctSteps);

        if (correctSteps == requiredSequence.Length)
        {
            Debug.Log("Puzzle Completed!");
            ResetSequence(true); // Optionally reset after completion for continuous play
        }
        else if (correctSteps < currentSequence.Count)
        {
            Debug.Log("Error in sequence. Resetting...");
            ResetSequence(false);
        }
    }

    int ValidateSequence()
    {
        int correctCount = 0;
        int sequenceLength = requiredSequence.Length;
        int startOffset = currentSequence[0] == requiredSequence[0] ? 0 : -1;

        if (startOffset == -1)
        {
            // Find the starting offset based on the first corridor in the current sequence
            for (int i = 0; i < sequenceLength; i++)
            {
                if (requiredSequence[i] == currentSequence[0])
                {
                    startOffset = i;
                    break;
                }
            }
        }

        if (startOffset != -1)
        {
            // Check the sequence from the found offset
            for (int i = 0; i < currentSequence.Count; i++)
            {
                if (i + startOffset < sequenceLength && currentSequence[i] == requiredSequence[i + startOffset])
                    correctCount++;
                else
                    break;
            }
        }

        Debug.Log($"Validated Sequence Length: {correctCount}. Current Pattern Checkpoint: {startOffset}");
        return correctCount;
    }

    void UpdateLights(int stepsCorrect)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(i < stepsCorrect);
        }
    }

    void ResetSequence(bool completed)
    {
        Debug.Log($"Resetting sequence. Completed: {completed}. Current Sequence Before Reset: {string.Join(", ", currentSequence)}");
        currentSequence.Clear();
        if (!completed) // Reset the last corridor ID to allow starting anew from the same corridor if needed
            lastCorridorID = -1;
        foreach (GameObject light in lights)
            light.SetActive(false);
    }
}
