using UnityEngine;
using System.Collections;

public class FallingSkullTrigger : MonoBehaviour
{
    public Transform skull;
    public Collider skullDeathCollider;

    public Vector3 fallRotation = new Vector3(90f, 0f, 0f);
    public float fallSpeed = 4f;
    public float deadlyTime = 0.8f;
    public float resetDelay = 3f;
    public float resetSpeed = 3f;

    private bool triggered = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;

    void Start()
    {
        startRotation = skull.rotation;
        targetRotation = Quaternion.Euler(skull.eulerAngles + fallRotation);

        if (skullDeathCollider != null)
            skullDeathCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(FallAndReset());
        }
    }

    IEnumerator FallAndReset()
    {
        if (skullDeathCollider != null)
            skullDeathCollider.enabled = true;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * fallSpeed;
            skull.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        skull.rotation = targetRotation;

        yield return new WaitForSeconds(deadlyTime);

        if (skullDeathCollider != null)
            skullDeathCollider.enabled = false;

        yield return new WaitForSeconds(resetDelay);

        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * resetSpeed;
            skull.rotation = Quaternion.Slerp(targetRotation, startRotation, t);
            yield return null;
        }

        skull.rotation = startRotation;
        triggered = false;
    }
}