using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform currentSpawn;

    public void SetSpawn(Transform newSpawn)
    {
        currentSpawn = newSpawn;
    }

    public void Respawn()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        transform.position = currentSpawn.position;

        if (controller != null)
            controller.enabled = true;
    }
}