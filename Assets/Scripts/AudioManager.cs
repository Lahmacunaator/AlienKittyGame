using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Example method to play an audio clip
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }

    // Other audio management methods can go here
}