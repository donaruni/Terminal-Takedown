using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text TimerText;
    public Image Fill;
    public float Max;

    void Start()
    {
        // Initializing the timer 
        time = Max;
    }

    void Update()
    {
        time -= Time.deltaTime;
        TimerText.text = "" + Mathf.CeilToInt(time); // Using CeilToInt to round up to 120 secs
        Fill.fillAmount = time / Max;

        if (time < 0)
            time = 0;
    }

    // Method to add time to the timer
    public void AddTime(float additionalTime)
    {
        time += additionalTime;

        // Ensuring the timer doesn't exceed its maximum
        if (time > Max)
        {
            time = Max;
        }
    }
}