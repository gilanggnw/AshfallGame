using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMusic : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
            MenuMusic.instance.GetComponent<AudioSource>().Pause();
    }
}