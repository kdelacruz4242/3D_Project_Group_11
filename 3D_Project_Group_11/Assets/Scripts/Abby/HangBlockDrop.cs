using System.Collections;
using UnityEngine;

public class CeilingDrop : MonoBehaviour
{
    [Tooltip("How close the player needs to be to trigger the drop")]
    public float triggerDistance = 3f;
    
    [Tooltip("How fast the block falls")]
    public float dropSpeed = 20f;
    
    [Tooltip("How fast the block returns to ceiling")]
    public float returnSpeed = 5f;
    
    [Tooltip("Y position of the floor - set this to match your floor")]
    public float floorY = 0f;
    
    [Tooltip("How close the block needs to be to the player to kill them")]
    public float killDistance = 3f;
    
    [Tooltip("Should the block return to ceiling after killing the player?")]
    public bool returnToStart = false;
    
    private Transform player;
    private bool triggered = false;
    private bool dropping = false;
    private bool canKill = false;
    private bool hasKilled = false;
    private Vector3 startPosition;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPosition = transform.position;
    }

    public bool IsDropping()
    {
        return dropping;
    }

    public bool CanKill()
    {
        return canKill;
    }

    void Update()
    {
        if (triggered) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < triggerDistance)
        {
            triggered = true;
            StartCoroutine(Drop());
        }
    }

    IEnumerator Drop()
    {
        canKill = true;
        hasKilled = false;
        dropping = true;
        
        while (dropping)
        {
            transform.position += Vector3.down * dropSpeed * Time.deltaTime;

            float distToPlayer = Vector3.Distance(transform.position, player.position);
            if (canKill && !hasKilled && distToPlayer < killDistance)
            {
                hasKilled = true;
                canKill = false;
                KillPlayer();
            }

            if (transform.position.y <= floorY)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    floorY,
                    transform.position.z
                );
                dropping = false;
                canKill = false;
                Debug.Log("Landed - canKill OFF");
            }
            yield return null;
        }
    }

    void KillPlayer()
    {
        Debug.Log("Player killed!");
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
            health.TakeDamage();

        if (returnToStart)
            StartCoroutine(ReturnToStart());
    }

    IEnumerator ReturnToStart()
    {
        yield return new WaitForSeconds(1f);

        while (Vector3.Distance(transform.position, startPosition) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPosition,
                returnSpeed * Time.deltaTime
            );
            yield return null;
        }

        transform.position = startPosition;
        yield return new WaitForSeconds(0.5f);
        hasKilled = false;
        triggered = false;
        Debug.Log("Returned to start!");
    }

    public void PlayerDied()
{
    if (returnToStart && triggered)
        StartCoroutine(ReturnToStart());
}
}