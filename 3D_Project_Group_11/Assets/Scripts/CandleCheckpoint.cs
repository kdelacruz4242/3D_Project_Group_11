using UnityEngine;

public class CandleCheckpoint : MonoBehaviour
{
    public GameObject candleLight;
    public Transform spawnPoint;
    public AudioSource checkpointSound;

    private bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            if (candleLight != null)
                candleLight.SetActive(true);

            if (checkpointSound != null)
                checkpointSound.Play();

            PlayerSpawn playerSpawn = other.GetComponent<PlayerSpawn>();

            if (playerSpawn != null)
            {
                playerSpawn.SetSpawn(spawnPoint);
            }
        }
    }
}