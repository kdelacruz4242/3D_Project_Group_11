using UnityEngine;
using System.Collections;

public class BookshelfFall : MonoBehaviour
{
    public Transform bookshelf;
    public float fallAngle = 80f;
    public float fallSpeed = 2f;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        Quaternion startRot = bookshelf.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(-80f, 0f, 0f);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * fallSpeed;
            bookshelf.rotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }
    }
}