using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time; //current time remaining
    public Text TimerText; //reference to UI text component
    public Image Fill; //reference to fill image
    public float Max; //max time value

    private bool hasTriggered = false; //flag ensures that time is up triggers once
    public HealthManager healthManager; //reference to players health manager

    void Update() //called once per frame
    {
        if (time > 0) //if time is remaining
        {
            time -= Time.deltaTime; //decrease time
            TimerText.text = "" + (int)time; //updates the UI text
            Fill.fillAmount = time / Max; //updates fill amount
        }

        if (time <= 0 && !hasTriggered) //if time has run out and trigger has not activated
        {
            hasTriggered = true; //ensures only runs once
            time = 0; //clamps time to 0

            if (healthManager != null) //sets players health to 0 to simulate death
            {
                healthManager.healthAmount = 0;
            }

            if (MusicManager.Instance != null) //play death music
            {
                MusicManager.Instance.PlayDeathMusic();
            }
        }
    }
}

