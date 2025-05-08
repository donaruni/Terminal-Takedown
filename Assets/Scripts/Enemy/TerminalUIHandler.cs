using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalUIHandler : MonoBehaviour
{
    public TMP_Text questionText; 
    public Button[] answerButtons; 
    public GameObject terminalUI; 
    private SoftDevQuestion currentQuestion;
    private GameObject clickedRobot;
    public SoftDevQuestionManager questionManager; 
    public Timer timer; // Reference to the Timer script

    // Call to show terminal
    public void OpenTerminal(GameObject robot)
    {
        Time.timeScale = 0;

        clickedRobot = robot;

        currentQuestion = questionManager.GetRandomQuestion();

        questionText.text = currentQuestion.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Count)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];

                int index = i; 
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false); 
            }
        }

        terminalUI.SetActive(true);
    }

    // Call when an answer button is clicked
    public void OnAnswerSelected(int index)
    {
        Time.timeScale = 1;

        terminalUI.SetActive(false);

        if (index == currentQuestion.correctAnswerIndex)
        {
            ExplodeRobot(clickedRobot);

            // Add 15 seconds to the timer
            if (timer != null)
            {
                timer.AddTime(15f);
            }
        }
    }

    // Explode the robot
    private void ExplodeRobot(GameObject robot)
    {
        // Only destroy the robot instance, not the prefab
        Destroy(robot);
        Debug.Log("Robot exploded!");
    }
}