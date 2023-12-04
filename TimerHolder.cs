using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerHolder : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;

    // Static variable to store the timer value across scenes
    private static float timerValue = 0f;
    private static float bestTime = float.MaxValue;

    // Boolean flag to indicate whether the timer should continue
    private static bool continueTimer = true;

    // Static instance to make it accessible from other scripts
    public static TimerHolder instance;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the timer with the stored value
        timerValue = Mathf.Max(0f, timerValue);
        bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue); // Load best time from PlayerPrefs
        UpdateBestTimeText();

        // Set the instance to this object
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update method called.");
        if (continueTimer)
        {
            // Update the timer value
            timerValue += Time.deltaTime;

            // Display the timer value (you can format it as needed)
            if (timerText != null)
            {
                timerText.text = "Time: " + timerValue.ToString("F2");
            }
        }
        Debug.Log("Current Time: " + timerValue);
    }

    // Method to reset the timer value
    public static void ResetTimer()
    {
        timerValue = 0f;
        continueTimer = true;
    }

    // Method to stop the timer
    public static void StopTimer()
    {
        continueTimer = false;

        // Check if the current time is better than the best time
        if (timerValue < bestTime)
        {
            bestTime = timerValue;
            PlayerPrefs.SetFloat("BestTime", bestTime); // Save best time to PlayerPrefs
            instance.UpdateBestTimeText();
            Debug.Log("New Best Time: " + bestTime);
        }
    }

    // Method to start the timer
    public static void StartTimer()
    {
        continueTimer = true;
    }

    // Method to get the current timer value
    public static float GetTimerValue()
    {
        return timerValue;
    }

    // Method to update the best time text
    private void UpdateBestTimeText()
    {
        if (bestTimeText != null)
        {
            bestTimeText.text = "Best: " + bestTime.ToString("F2");
        }
    }
}