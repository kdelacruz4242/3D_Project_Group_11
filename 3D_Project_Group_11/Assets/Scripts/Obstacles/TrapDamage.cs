using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSpawn playerSpawn = other.GetComponent<PlayerSpawn>();
            if (playerSpawn != null)
                playerSpawn.Respawn();
        }
    }
}