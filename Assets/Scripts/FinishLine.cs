using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the current active scene
            // Scene currentScene = SceneManager.GetActiveScene();

            // // Check the current scene name and load the next scene
            // if (currentScene.name == "Level1")
            // {
            //     SceneManager.LoadScene("Level2");
            // }
            // else if (currentScene.name == "Level2")
            // {
            //     SceneManager.LoadScene("Level3");
            // }

            if (audioManager != null)
            {
                audioManager.OnGoalReached();
            }

            // Add any additional logic for reaching the goal here
            Debug.Log("Goal reached!");

            StartCoroutine(LoadNextSceneWithDelay());

        }
    }
     private IEnumerator LoadNextSceneWithDelay()
{
    // Wait for the audio to finish playing
    if (audioManager != null)
    {
        yield return new WaitForSeconds(audioManager.GetSFXClipLength());
    }

    // Get the current active scene
    Scene currentScene = SceneManager.GetActiveScene();

    // Check the current scene name and load the next scene
    if (currentScene.name == "Level1")
    {
        SceneManager.LoadScene("Level2");
    }
    else if (currentScene.name == "Level2")
    {
        SceneManager.LoadScene("Level3");
    }
}
}

