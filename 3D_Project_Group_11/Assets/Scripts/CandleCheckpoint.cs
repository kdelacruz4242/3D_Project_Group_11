using UnityEngine;

public class CandleCheckpoint : MonoBehaviour
{
    public GameObject candleLight;
    public Transform spawnPoint;

    private bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            if (candleLight != null)
                candleLight.SetActive(true);

           other.transform.position = spawnPoint.position;
        }
    }
}