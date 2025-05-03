using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkScript : MonoBehaviour
{
        private AudioManager audioManager;

    public float jumpBoost = 100f; // Amount to add to the player's jump force
    private float originalJump;   // To store the player's original jump force

    // Start is called before the first frame update
    void Start()
    {
                audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with the gem
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerMovement script from the player
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Store the original jump force
                originalJump = playerMovement.Jump;

                // Increase the player's jump force
                playerMovement.Jump += jumpBoost;
                Debug.Log("Player's jump force increased!");

                // Deactivate the gem
                gameObject.SetActive(false);
            }
             // Play gem audio
            if (audioManager != null)
            {
                audioManager.PlayGemAudio();
            }

            // Logic for collecting the gem
            Debug.Log("Gem collected!");
        }
    }

    // Method to reset the player's jump force (optional, if needed elsewhere)
    public void ResetJumpForce(PlayerMovement playerMovement)
    {
        if (playerMovement != null)
        {
            playerMovement.Jump = originalJump;
        }
    }
}
