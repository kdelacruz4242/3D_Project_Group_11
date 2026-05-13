using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour
{
    public Transform currentSpawn;
    public AudioClip deathSound;
    public float invincibleTime = 1.5f;

    private AudioSource audioSource;
    private Image damageFlash;
    private CharacterController controller;
    private bool isInvincible = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;

        GameObject canvas = new GameObject("DamageCanvas");
        Canvas c = canvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();

        GameObject img = new GameObject("FlashImage");
        img.transform.SetParent(canvas.transform, false);
        damageFlash = img.AddComponent<Image>();
        damageFlash.color = new Color(1, 0, 0, 0);
        damageFlash.rectTransform.anchorMin = Vector2.zero;
        damageFlash.rectTransform.anchorMax = Vector2.one;
    }

    public void SetSpawn(Transform newSpawn)
    {
        currentSpawn = newSpawn;
    }

    public void Respawn()
    {
        if (isInvincible) return;
        StartCoroutine(DoRespawn());
    }

    IEnumerator DoRespawn()
    {
        isInvincible = true;

        if (deathSound != null)
            audioSource.PlayOneShot(deathSound);

        // notify ceiling blocks
        CeilingDrop[] ceilingBlocks = FindObjectsByType<CeilingDrop>(FindObjectsSortMode.None);
        foreach (CeilingDrop block in ceilingBlocks)
            block.PlayerDied();

        // red flash
        damageFlash.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.2f);
        damageFlash.color = new Color(1, 0, 0, 0);

        // teleport
        controller.enabled = false;
        if (currentSpawn != null)
            transform.position = currentSpawn.position;
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true;

        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}