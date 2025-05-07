using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar; //UI image representing health bar
    public float healthAmount = 100f; //current health
    public GameObject playAgain; //reference to play again panel

    private bool isDead = false; //flag tracks if player is dead

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playAgain != null) //makes sure the play again UI is hidden at start
        {
            playAgain.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //checks if health is 0 or below and the player is not dead
        if (healthAmount <= 0 && !isDead) //CHANGE THIS PART TO WHAT YOU WANT TO HAPPEN IF THE PLAYER HEALTH DROPS TO 0 (PLAYER DIES!)
        {
            isDead= true;
            MusicManager.Instance.PlayDeathMusic(); //play death music
            if (playAgain != null) //shows play again UI and pauses game
            {
                playAgain.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void TakeDamage(float damage) //call method to apply damage to player
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f; //update the health bar UI
    }

    public void Heal(float healingAmount) //call method to heal player
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); //clamp health between 0 and 100

        healthBar.fillAmount = healthAmount / 100f; //update the health bar UI
    }

    public void RestartGame() //restarts game by loading current scene
    {
        Time.timeScale = 1f; //resumes game time
    
        if (MusicManager.Instance != null) //resumes background music
        {
            MusicManager.Instance.PlayBackgroundMusic(true, MusicManager.Instance.backgroundMusic);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reloads active scene
    }


    public bool IsDead() //returns whether player is dead
    {
        return isDead;
    }

    public void MarkAsDead() //marks player as dead and handles UI and music
    {
        isDead = true;
        if (playAgain != null) //show play again UI and pause game
        {
            playAgain.SetActive(true);
            Time.timeScale = 0f;
        }
        MusicManager.Instance.PlayBackgroundMusic(true, MusicManager.Instance.deathMusic); //play death music
    }


}
