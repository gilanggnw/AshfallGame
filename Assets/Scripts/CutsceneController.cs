using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string nextSceneName; // Add this in inspector
    private bool isVideoFinished = false;

    private void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        if (string.IsNullOrEmpty(nextSceneName))
            Debug.LogError("Next Scene Name not set in inspector!");

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || isVideoFinished)
        {
            LoadGameScene();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        isVideoFinished = true;
    }

    private void LoadGameScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        else
            Debug.LogError("Cannot load next scene - scene name not set!");
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}