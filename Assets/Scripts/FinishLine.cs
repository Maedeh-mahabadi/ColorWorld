using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}

