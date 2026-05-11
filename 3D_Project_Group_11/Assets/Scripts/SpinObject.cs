using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 400);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}