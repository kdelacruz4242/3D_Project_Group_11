using UnityEngine;

public class SpikeRollMove : MonoBehaviour
{
    [Tooltip("How fast the spike roll moves")]
    public float moveSpeed = 5f;
    
    [Tooltip("How far it moves before turning around")]
    public float moveDistance = 10f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * moveDistance;
    }

    void Update()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                movingForward = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
                movingForward = true;
        }
    }
}