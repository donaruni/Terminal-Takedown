using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (healthAmount <= 0) //CHANGE THIS PART TO WHAT YOU WANT TO HAPPEN IF THE PLAYER HEALTH DROPS TO 0 (PLAYER DIES!)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //for now it is set to reload the level from start after player dies.
        }

        if (Input.GetKeyDown(KeyCode.Return)) //TESTS FOR DAMAGE TAKING WITH (RETURN/ENTER KEY!) EDIT THIS IN FUTURE FOR HOW U WANT TO TAKE DAMAGE
        {
            TakeDamage(20); //edit this part for damage taken
        }

        if (Input.GetKeyDown(KeyCode.Space)) //TESTS FOR HEALING WITH (SPACEBAR KEY!) EDIT THIS IN FUTURE FOR HOW U WANT TO HEAL DAMAGE TAKEN!
        {
            Heal(10); //edit this part for damage healed
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
}
