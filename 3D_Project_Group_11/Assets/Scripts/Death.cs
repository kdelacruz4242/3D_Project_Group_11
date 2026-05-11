using UnityEngine;
using System.Collections;

public class SpikeDeath : MonoBehaviour
{
    public Transform spawnPoint;
    public AudioSource deathSound;
    public float respawnDelay = 0.4f;

    private bool isRespawning = false;

    void OnTriggerEnter(Collider other)
    {
        if (isRespawning) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer(other));
        }
    }

    IEnumerator RespawnPlayer(Collider player)
    {
        isRespawning = true;

        if (deathSound != null)
        {
            deathSound.Play();
        }

        yield return new WaitForSeconds(respawnDelay);

        CharacterController controller = player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        player.transform.position = spawnPoint.position;

        if (controller != null)
            controller.enabled = true;

        isRespawning = false;
    }
}