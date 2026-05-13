using UnityEngine;

public class AxeSound : MonoBehaviour
{
    public AudioClip swingSound;
    public float swingInterval = 2f;
    public float soundDelay = 0.8f;
    public float maxDistance = 5f;
    private AudioSource audioSource;

    void Start()
    {
        // create audio source through code
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.minDistance = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.playOnAwake = false;
        InvokeRepeating("PlaySwingSound", soundDelay, swingInterval);
    }

    void PlaySwingSound()
    {
        if (audioSource != null && swingSound != null)
            audioSource.PlayOneShot(swingSound);
    }
}