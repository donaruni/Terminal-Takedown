using System.Collections.Generic;
using UnityEngine;

public class SoftDevQuestion : MonoBehaviour
{
    public string question; // The question text
    public List<string> answers; // The list of answers
    public int correctAnswerIndex; // Index of the correct answer
}
public class SoftDevQuestionManager : MonoBehaviour
{
    public List<SoftDevQuestion> questionObjects; // List of GameObjects with SoftDevQuestion

    // Get a random question
    public SoftDevQuestion GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionObjects.Count);
        return questionObjects[randomIndex];
    }
}