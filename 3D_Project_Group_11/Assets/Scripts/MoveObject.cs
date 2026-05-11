using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float distance = 5f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + moveDirection.normalized * distance;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPos, endPos, t);
    }
}