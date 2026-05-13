using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpiderTrap : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 8f;
    public float moveSpeed = 8f;
    public float killDistance = 2f;
    public AudioClip jumpscareSound;
    
    private Animation anim;
    private bool triggered = false;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private AudioSource audioSource;
    private Image blackScreen;

    void Start()
    {
        anim = GetComponent<Animation>();
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;
        
        // save starting position
        startPosition = transform.position;
        startRotation = transform.rotation;

        // add audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = jumpscareSound;

        // create black screen
        GameObject canvas = new GameObject("SpiderCanvas");
        Canvas c = canvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        c.sortingOrder = 999;
        canvas.AddComponent<CanvasScaler>();

        GameObject img = new GameObject("BlackScreen");
        img.transform.SetParent(canvas.transform, false);
        blackScreen = img.AddComponent<Image>();
        blackScreen.color = new Color(0, 0, 0, 0);
        blackScreen.rectTransform.anchorMin = Vector2.zero;
        blackScreen.rectTransform.anchorMax = Vector2.one;

        anim.Play("idle");
    }

    void Update()
    {
        if (triggered) return;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < triggerDistance)
        {
            triggered = true;
            StartCoroutine(ChasePlayer());
        }
    }

    IEnumerator ChasePlayer()
    {
        anim.Play("walk");
        isMoving = true;

        while (isMoving)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            Vector3 direction = (player.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (distance < killDistance)
            {
                isMoving = false;
                StartCoroutine(KillPlayer());
            }
            yield return null;
        }
    }

    IEnumerator KillPlayer()
    {
        // play attack animation and sound
        anim.Play("attack1");
        if (jumpscareSound != null)
            audioSource.Play();

        // black screen
        blackScreen.color = new Color(0, 0, 0, 1f);

        yield return new WaitForSeconds(0.5f);

        // respawn player
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null) controller.enabled = false;
        player.transform.position = CheckpointManager.lastCheckpoint;
        if (controller != null) controller.enabled = true;

        yield return new WaitForSeconds(0.5f);

        // fade black screen out
        blackScreen.color = new Color(0, 0, 0, 0);

        // return spider to hiding spot
        transform.position = startPosition;
        transform.rotation = startRotation;
        anim.Play("idle");

        yield return new WaitForSeconds(1f);
        triggered = false;
    }
}