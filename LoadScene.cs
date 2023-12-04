using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    private int finishCollisions = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as "Finish"
        if (other.CompareTag("Player"))
        {
            // Increase the collision count
            finishCollisions++;

            // Check if the required number of collisions has occurred
            if (finishCollisions == 2)
            {
                // Reset the collision count
                finishCollisions = 0;

                // Check if the current scene is Scene3
                if (SceneManager.GetActiveScene().name == "Scene3")
                {
                    // Stop the timer only in Scene3
                    TimerHolder.StopTimer();

                    // Wait for a short delay to ensure the UI updates before scene transition
                    StartCoroutine(LoadNextSceneWithDelay());
                }

                // Load the next scene
                NextLevel();
            }
        }
    }

    private IEnumerator LoadNextSceneWithDelay()
    {
        // Wait for a short delay to ensure the UI updates before scene transition
        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed

        // Load the next scene
        NextLevel();
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there is a next scene
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // If there is no next scene, you can handle it as needed (e.g., restart the game).
            Debug.LogWarning("No next scene available.");
        }
    }
}
