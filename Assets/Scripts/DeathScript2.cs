using UnityEngine;

public class DeathScript2 : MonoBehaviour
{
    private AudioManager audioManager;

    public GameObject grayObject;
    public GameObject GemObject;
    public GameObject startPoint;
    public GameObject player;
    public GameObject pinkGem;
    private float originalJump = 300f; // Default jump force (set this to the player's default jump value)




    void Start()
    {
                audioManager = FindObjectOfType<AudioManager>();

        // Optionally, initialize the original jump value from the player's script
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            originalJump = playerMovement.Jump;
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reset the player's position
            player.transform.position = startPoint.transform.position;

            // Reset the player's jump force
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.Jump = originalJump;
                Debug.Log("Player's jump force reset to original value!");
            }

            // Reactivate the gray object and gem
            grayObject.SetActive(true);
            GemObject.SetActive(true);
            if (pinkGem != null)
            {
                pinkGem.SetActive(true);
                Debug.Log("Pink gem reactivated!");
            }
             // Play death audio
            if (audioManager != null)
            {
                audioManager.PlayDeathAudio();
            }

            // Reset player position or other logic
            Debug.Log("Player died!");
        }
    }
}