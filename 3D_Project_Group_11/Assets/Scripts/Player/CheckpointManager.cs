using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static Vector3 lastCheckpoint;

    void Start()
    {
        // Set the first checkpoint at the start of the level
        lastCheckpoint = GameObject.FindWithTag("Player").transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastCheckpoint = transform.position;
            Debug.Log("Checkpoint saved at: " + lastCheckpoint);
        }
    }
}
