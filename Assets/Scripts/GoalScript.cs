using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
        public PauseMenuScript pauseMenuScript; // Reference to the PauseMenuScript

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with the goal object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Trigger the pause menu
            if (pauseMenuScript != null)
            {
                pauseMenuScript.TogglePauseMenu();
            }
        }
    }
}
