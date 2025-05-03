using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScript : MonoBehaviour
{
        private AudioManager audioManager;

    public GameObject grayObject;
    public GameObject GemObject;
    public GameObject player;
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
        if(other.gameObject.CompareTag("Player")){
            grayObject.SetActive(false);
            GemObject.SetActive(false);
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
