using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalUIHandler : MonoBehaviour
{
    public TMP_Text questionText; // For displaying the question
    public Button[] answerButtons; // Buttons for multiple-choice answers
    public GameObject terminalUI; // The terminal UI GameObject
    private SoftDevQuestion currentQuestion;
    private GameObject clickedRobot; // Changed to GameObject for consistency

    public SoftDevQuestionManager questionManager; // Reference to the SoftDevQuestionManager

    public GameObject explosionPrefab;

    // Call this to show the terminal
    public void OpenTerminal(GameObject robot)
    {
        // Freeze the game
        Time.timeScale = 0;

        // Set the clicked robot
        clickedRobot = robot;

        // Get a random question
        currentQuestion = questionManager.GetRandomQuestion();

        // Display the question
        questionText.text = currentQuestion.question;

        // Assign answers to buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Count)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];

                // Remove all listeners first, then add the appropriate listener
                int index = i; // Capture the loop variable
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));}
            else
            {
                answerButtons[i].gameObject.SetActive(false); // Hide unused buttons
            }
        }

        // Show the terminal UI
        terminalUI.SetActive(true);
    }

    // Call this when an answer button is clicked
    public void OnAnswerSelected(int index)
    {
        // Unfreeze the game
        Time.timeScale = 1;

        // Close the terminal
        terminalUI.SetActive(false);

        // Check if the answer is correct
        if (index == currentQuestion.correctAnswerIndex)
        {
            // Destroy the clicked robot
            ExplodeRobot(clickedRobot);
        }
    }

    // Explode the robot
    private void ExplodeRobot(GameObject robot)
    {
    
    if (explosionPrefab != null)
    {
        Instantiate(explosionPrefab, robot.transform.position, Quaternion.identity);
    }

    // Destroy the robot 
    Destroy(robot); 
    Debug.Log("Robot exploded!");
    }
   
}