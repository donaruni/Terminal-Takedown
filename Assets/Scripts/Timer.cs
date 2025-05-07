using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text TimerText;
    public Image Fill;
    public float Max;

    private bool hasTriggered = false;
    public HealthManager healthManager;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText.text = "" + (int)time;
            Fill.fillAmount = time / Max;
        }

        if (time <= 0 && !hasTriggered)
        {
            hasTriggered = true;
            time = 0;

            if (healthManager != null)
            {
                healthManager.healthAmount = 0; // Simulate death
            }

            if (MusicManager.Instance != null)
            {
                MusicManager.Instance.PlayDeathMusic();
            }
        }
    }
}

