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
        // Initialize the timer (optional)
        time = Max;
    }

    void Update()
    {
        time -= Time.deltaTime;
        TimerText.text = "" + Mathf.CeilToInt(time); // Use CeilToInt to round up
        Fill.fillAmount = time / Max;

        if (time < 0)
            time = 0;
    }

    // Method to add time to the timer
    public void AddTime(float additionalTime)
    {
        time += additionalTime;

        // Ensure the timer doesn't exceed its maximum
        if (time > Max)
        {
            time = Max;
        }
    }
}