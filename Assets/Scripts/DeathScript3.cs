using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript3 : MonoBehaviour
{
    public GameObject player; // Reference to the player
    public GameObject lightObject; // Reference to the Light object
    public GameObject yellowGem; // Reference to the yellow gem
    public GameObject otherGem; // Reference to the second gem
    public GameObject startPoint; // Reference to the starting point
    public Camera mainCamera; // Reference to the main camera
    private float originalJump = 300f; // Default jump value
    private Color originalCameraColor; // To store the original camera color

    void Start()
    {
        // Store the original camera color
        if (mainCamera != null)
        {
            originalCameraColor = mainCamera.backgroundColor;
        }

        // Optionally, initialize the original jump value from the player's script
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            originalJump = playerMovement.Jump;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reset the player's position to the starting point
            if (startPoint != null && player != null)
            {
                player.transform.position = startPoint.transform.position;
                Debug.Log("Player's position reset to the starting point!");
            }

            // Reset the player's jump amount
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.Jump = originalJump;
                Debug.Log("Player's jump force reset to original value!");
            }

            // Deactivate the Light object
            if (lightObject != null)
            {
                lightObject.SetActive(false);
                Debug.Log("Light object deactivated!");
            }

            // Restore the yellow gem
            if (yellowGem != null)
            {
                yellowGem.SetActive(true);
                Debug.Log("Yellow gem restored!");
            }

            // Restore the other gem
            if (otherGem != null)
            {
                otherGem.SetActive(true);
                Debug.Log("Other gem restored!");
            }

            // Reset the camera color
            if (mainCamera != null)
            {
                mainCamera.backgroundColor = originalCameraColor;
                Debug.Log("Camera color reset to original!");
            }
        }
    }
}