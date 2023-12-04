using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    // Attach this method to the button's click event in the Unity Editor
    public void OnHomeButtonClick()
    {
        // Load the "StartScene"
        SceneManager.LoadScene("StartScene");
    }
}
