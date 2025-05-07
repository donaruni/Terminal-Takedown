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
    public float chainReactionRadius = 5f; // Radius for chain reaction

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
        }
    }

    // Explode the robot and trigger chain reaction
    private void ExplodeRobot(GameObject robot)
    {
        if (robot == null) return;

        // Spawn the explosion prefab at the robot's position
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, robot.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Explosion prefab is not assigned!");
        }

        // Trigger chain reaction for nearby robots
        TriggerChainReaction(robot);

        // Destroy the robot GameObject
        Destroy(robot);
        Debug.Log("Robot exploded!");
    }

    // Trigger chain reaction for nearby robots
    private void TriggerChainReaction(GameObject robot)
    {
        // Find all colliders within the chain reaction radius
        Collider[] nearbyRobots = Physics.OverlapSphere(robot.transform.position, chainReactionRadius);

        foreach (Collider collider in nearbyRobots)
        {
            GameObject nearbyRobot = collider.gameObject;

            // Ensure the nearby GameObject is a robot and not the already-exploded one
            if (nearbyRobot != robot && nearbyRobot.CompareTag("Robot"))
            {
                ExplodeRobot(nearbyRobot); // Trigger explosion for the nearby robot
            }
        }
    }
}