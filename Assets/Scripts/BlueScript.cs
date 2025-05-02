using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScript : MonoBehaviour
{
    public GameObject waterObject; // Reference to the Water object

    void Start()
    {
        // Ensure the water object is initially inactive
        if (waterObject != null)
        {
            waterObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player collides with the gem
        if (other.gameObject.CompareTag("Player"))
        {
            // Deactivate the gem (this object)
            gameObject.SetActive(false);

            // Activate the water object
            if (waterObject != null)
            {
                waterObject.SetActive(true);
            }
        }
    }
}