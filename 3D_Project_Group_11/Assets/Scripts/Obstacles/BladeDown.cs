using System.Collections;
using UnityEngine;

public class BladeDown : MonoBehaviour
{
    [Tooltip("How close the player needs to be to trigger the blade going down")]
    public float triggerDistance = 5f;

    private Transform player;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        // get animator from parent
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (player == null || anim == null) return;
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < triggerDistance)
            anim.SetBool("enabled", true);
        else
            anim.SetBool("enabled", false);
    }
}