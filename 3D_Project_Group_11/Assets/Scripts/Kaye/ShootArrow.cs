using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public Transform arrow;
    public float speed = 10f;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    void Update()
    {
        if (triggered)
        {
            arrow.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}