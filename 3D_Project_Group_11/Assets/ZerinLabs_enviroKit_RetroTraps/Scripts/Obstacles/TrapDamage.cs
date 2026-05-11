using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    BoxCollider trapCollider;
    Transform spikes;

    void Start()
    {
        trapCollider = GetComponent<BoxCollider>();

        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "decoTrap_spikesfloor_spikes")
            {
                spikes = child;
                break;
            }
        }
    }

    void Update()
    {
        if (spikes != null && trapCollider != null)
        {
            // check position AND scale on all axes
            Debug.Log("Pos: " + spikes.localPosition + " Scale: " + spikes.localScale);
            
            // enable when scale Y is above 0.5 (spikes growing up)
            trapCollider.enabled = spikes.localScale.z > -0.5f;
        }

        if (trapCollider != null && trapCollider.enabled)
        {
            Collider[] hits = Physics.OverlapBox(
                trapCollider.bounds.center,
                trapCollider.bounds.extents
            );

            foreach (Collider hit in hits)
            {
                PlayerHealth health = hit.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage();
                }
            }
        }
    }
}