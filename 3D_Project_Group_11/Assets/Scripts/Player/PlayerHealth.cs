using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float invincibleTime = 1.5f;
    public AudioClip deathSound;
    
    bool isInvincible = false;
    Image damageFlash;
    CharacterController controller;
    AudioSource audioSource;
    PlayerSpawn playerSpawn;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerSpawn = GetComponent<PlayerSpawn>();
        CheckpointManager.lastCheckpoint = transform.position;

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

    public void TakeDamage()
    {
        if (isInvincible) return;

        if (deathSound != null)
            audioSource.PlayOneShot(deathSound);

        CeilingDrop[] ceilingBlocks = FindObjectsByType<CeilingDrop>(FindObjectsSortMode.None);
        foreach (CeilingDrop block in ceilingBlocks)
            block.PlayerDied();

        StartCoroutine(FlashRed());
        StartCoroutine(Respawn());
    }

    IEnumerator FlashRed()
    {
        damageFlash.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.2f);
        damageFlash.color = new Color(1, 0, 0, 0);
    }

    IEnumerator Respawn()
{
    isInvincible = true;
    
    if (playerSpawn != null && playerSpawn.currentSpawn != null)
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        transform.position = playerSpawn.currentSpawn.position;
        yield return new WaitForSeconds(0.1f); // small delay
        if (cc != null) cc.enabled = true;
    }
    else
    {
        controller.enabled = false;
        transform.position = CheckpointManager.lastCheckpoint;
        yield return new WaitForSeconds(0.1f); // small delay
        controller.enabled = true;
    }

    yield return new WaitForSeconds(invincibleTime);
    isInvincible = false;
}
}