using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public GameObject playAgain;

    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playAgain != null)
        {
            playAgain.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0 && !isDead) //CHANGE THIS PART TO WHAT YOU WANT TO HAPPEN IF THE PLAYER HEALTH DROPS TO 0 (PLAYER DIES!)
        {
            isDead= true;
            MusicManager.Instance.PlayDeathMusic();
            if (playAgain != null)
            {
                playAgain.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
    
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PlayBackgroundMusic(true, MusicManager.Instance.backgroundMusic);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public bool IsDead()
    {
        return isDead;
    }

    public void MarkAsDead()
    {
        isDead = true;
        if (playAgain != null)
        {
            playAgain.SetActive(true);
            Time.timeScale = 0f;
        }
        MusicManager.Instance.PlayBackgroundMusic(true, MusicManager.Instance.deathMusic);
    }


}
