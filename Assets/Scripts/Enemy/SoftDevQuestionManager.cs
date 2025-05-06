using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoftDevQuestion
{
    public string question; // The question text
    public List<string> answers; // The list of answers
    public int correctAnswerIndex; // Index of the correct answer
}

public class SoftDevQuestionManager : MonoBehaviour
{
    public List<SoftDevQuestion> questions; // List of soft dev questions

    // Get a random question
    public SoftDevQuestion GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        return questions[randomIndex];
    }
}