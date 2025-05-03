using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the Pause Menu UI

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenu != null)
        {
            bool isActive = pauseMenu.activeSelf;
            pauseMenu.SetActive(!isActive);

            // Pause or resume the game
            Time.timeScale = isActive ? 1f : 0f;
        }
    }

    public void RestartGame()
    {
        // Resume the game time
        Time.timeScale = 1f;

        // Load Level 1
        SceneManager.LoadScene("Level1");
    }

    public void ResumeGame()
    {
        // Resume the game time
        Time.timeScale = 1f;

        // Hide the pause menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}