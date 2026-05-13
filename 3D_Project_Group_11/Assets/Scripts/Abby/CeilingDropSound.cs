using UnityEngine;

public class CeilingDropSound : MonoBehaviour
{
    public AudioClip landSound;
    public float maxDistance = 8f;
    
    private AudioSource audioSource;
    private CeilingDrop ceilingDrop;
    private bool hasPlayedLand = false;
    private bool wasFalling = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.minDistance = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.playOnAwake = false;
        ceilingDrop = GetComponent<CeilingDrop>();
    }

    void Update()
    {
        if (ceilingDrop == null) return;

        if (ceilingDrop.IsDropping())
            wasFalling = true;

        if (wasFalling && !ceilingDrop.IsDropping() && !hasPlayedLand)
        {
            hasPlayedLand = true;
            wasFalling = false;
            if (landSound != null)
                audioSource.PlayOneShot(landSound);
            Debug.Log("Land sound played!");
        }
    }
}