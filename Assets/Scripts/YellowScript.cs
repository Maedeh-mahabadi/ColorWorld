using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowScript : MonoBehaviour
{
        private AudioManager audioManager;

    public Camera mainCamera; // Reference to the main camera
    public GameObject yellowGem; 
    public GameObject Light; // Reference to the yellow gem
// Reference to the yellow gem

    void Start()
    {
                audioManager = FindObjectOfType<AudioManager>();

        // Ensure the main camera is assigned
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with the yellow gem
        if (collision.gameObject.CompareTag("Player"))
        {
            // Change the camera's background color to 71413B
            if (mainCamera != null)
            {
                mainCamera.backgroundColor = new Color32(113, 65, 59, 255); // RGB values for 71413B
            }

            // Activate all objects with the "Light" tag
            if (Light != null)
            {
                Light.SetActive(true);
            }

            // Deactivate the yellow gem
            if (yellowGem != null)
            {
                yellowGem.SetActive(false);
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
}