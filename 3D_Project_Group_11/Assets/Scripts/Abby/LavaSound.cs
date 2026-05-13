using UnityEngine;

public class LavaSound : MonoBehaviour
{
    [Tooltip("The lava bubbling sound clip")]
    public AudioClip lavaSound;
    
    [Tooltip("How far the player can hear the lava")]
    public float maxDistance = 10f;
    
    [Tooltip("Volume of the lava sound")]
    public float volume = 1f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = lavaSound;
        audioSource.loop = true;
        audioSource.spatialBlend = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.minDistance = 1f;
        audioSource.volume = volume;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.playOnAwake = true;
        audioSource.Play();
    }
}