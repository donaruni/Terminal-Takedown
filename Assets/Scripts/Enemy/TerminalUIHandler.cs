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
    public GameObject explosionPrefab; 

    public Timer timer;

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
        // Instantiate the explosion animation at the robot's position
        if (robot != null)
        {
            // Check if the explosion prefab is assigned
            if (explosionPrefab != null)
            {
                // Instantiate the explosion prefab
                GameObject explosion = Instantiate(explosionPrefab, robot.transform.position, Quaternion.identity);

                // Trigger the explosion animation
                Animator explosionAnimator = explosion.GetComponent<Animator>();
                if (explosionAnimator != null)
                {
                    explosionAnimator.SetTrigger("OnEnemyDeath");
                }
                else
                {
                    Debug.LogWarning("No Animator component found on the explosion prefab!");
                }
            }
            else
            {
                Debug.LogWarning("Explosion prefab is not assigned!");
            }

            // Destroy the robot GameObject after the explosion
            Destroy(robot);

            Debug.Log("Robot exploded!");
        }
    }
}