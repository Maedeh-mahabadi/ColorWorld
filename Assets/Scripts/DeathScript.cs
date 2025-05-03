 
using UnityEngine;

public class DeathScript : MonoBehaviour
{
        private AudioManager audioManager;

    public GameObject waterObject;
    public GameObject GemObject;
    public GameObject startPoint;
    public GameObject player;
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
        if(other.gameObject.CompareTag("Player")){
            player.transform.position=startPoint.transform.position;
        waterObject.SetActive(false);
        GemObject.SetActive(true);
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
