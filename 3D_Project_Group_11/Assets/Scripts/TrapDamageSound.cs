using UnityEngine;

public class TrapDamageSound : MonoBehaviour
{
    public AudioSource trapSound;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            if (trapSound != null)
            {
                trapSound.Play();
            }

            health.TakeDamage();
        }
    }
}