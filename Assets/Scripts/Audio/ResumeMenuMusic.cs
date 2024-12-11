using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeMenuMusic : MonoBehaviour 
{
    void Start()
    {
        // Only play when first entering menu
        if (SceneManager.GetActiveScene().name == "Menu" && MenuMusic.instance != null)
        {
            AudioSource audioSource = MenuMusic.instance.GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}