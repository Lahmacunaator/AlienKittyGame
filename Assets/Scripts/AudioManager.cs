using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Static instance of AudioManager which allows it to be accessed by any other script.
    public static AudioManager Instance { get; private set; }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if instance already exists and destroy this one if it does
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Save this instance as the singleton instance
        Instance = this;

        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Example method to play an audio clip
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }

    // Other audio management methods can go here
}