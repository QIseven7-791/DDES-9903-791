using UnityEngine;

public class DelayedAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay = 3f;

    void Start()
    {
        Invoke(nameof(PlayAudio), delay);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}

