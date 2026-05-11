using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage();
        }
    }
}