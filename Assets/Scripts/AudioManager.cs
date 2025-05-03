using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]

    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]

public AudioClip background1;
public AudioClip background2;
public AudioClip background3;

public AudioClip death;

public AudioClip level;

public AudioClip gem;
public AudioClip win;



    // Start is called before the first frame update
    void Start()
    {
        // Get the active scene name
        string currentScene = SceneManager.GetActiveScene().name;

        // Play the appropriate background music based on the scene
        if (currentScene == "Level1")
        {
            musicSource.clip = background1;
        }
        else if (currentScene == "Level2")
        {
            musicSource.clip = background2;
        }
        else if (currentScene == "Level3")
        {
            musicSource.clip = background3;
        }

        // Play the selected background music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGoalReached()
    {
        // Stop the background music
        musicSource.Stop();

        // Get the active scene name
        string currentScene = SceneManager.GetActiveScene().name;

        // Play the appropriate audio based on the level
        if (currentScene == "Level3")
        {
            SFXSource.clip = win; // Play win audio in Level 3
        }
        else
        {
            SFXSource.clip = level; // Play level audio in Level 1 and Level 2
        }

        // Play the selected audio
        SFXSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayDeathAudio()
    {
    PlaySFX(death); // Play the death audio
    }

    public void PlayGemAudio()
    {
    PlaySFX(gem); // Play the gem audio
    }
    public float GetSFXClipLength()
{
    if (SFXSource.clip != null)
    {
        return SFXSource.clip.length; // Return the length of the current clip
    }
    return 0f; // Return 0 if no clip is assigned
}
}
