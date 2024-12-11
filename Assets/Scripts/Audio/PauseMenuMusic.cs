using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMusic : MonoBehaviour
{
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Check for any scene named Level 1 through Level 7
        if (currentScene == "Level 1" || 
            currentScene == "Level 2" || 
            currentScene == "Level 3" || 
            currentScene == "Level 4" || 
            currentScene == "Level 5" || 
            currentScene == "Level 6" || 
            currentScene == "Level 7")
        {
            if (MenuMusic.instance != null && MenuMusic.instance.GetComponent<AudioSource>() != null)
            {
                MenuMusic.instance.GetComponent<AudioSource>().Pause();
            }
        }
    }
}