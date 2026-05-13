using UnityEngine;

public class SpikeRollSound : MonoBehaviour
{
    public AudioClip rollSound;
    public float maxDistance = 10f;
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = rollSound;
        audioSource.loop = true;
        audioSource.spatialBlend = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.minDistance = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.playOnAwake = true;
        audioSource.Play();
    }
}