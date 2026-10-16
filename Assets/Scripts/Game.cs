using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{

    /*
     * Private Members
     */
    private Queue<int> solution;
    private Queue<int> currentAnswer;


    void Start()
    {
        solution = new Queue<int>();
        currentAnswer = new Queue<int>();
    }


    public void Enqueue(int tone)
    {
        solution.Enqueue(tone);
    }

    /*
     * Compares the answer to the solution
     * Players the answer back to the players
     * The full song will play if they solve the puzzle
     */
    public void CheckAnswer()
    {
        // Iterate over answer queue and play each tone using the audio manager
    }

    /*
     * Plays the solution for the players
     * Happens by default at the beginning of the level
     */
    public void PlaySolution()
    {
        // Iterate over answer queue and play each tone using the audio manager
    }

    /*
     * Resets the answer queue, allowing the players to start over
     */
    public void ResetSolution()
    {
        currentAnswer.Clear();
    }
}
