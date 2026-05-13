using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrapDamageSound : MonoBehaviour
{
    public AudioSource trapSound;
    public float respawnDelay = 0.4f;
    public float flashAlpha = 0.5f;
    public float flashDuration = 0.2f;

    private bool isRespawning = false;
    private static Image damageFlash;

    void Start()
    {
        CreateFlashCanvas();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isRespawning) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer(other));
        }
    }

    IEnumerator RespawnPlayer(Collider player)
    {
        isRespawning = true;

        if (trapSound != null)
            trapSound.Play();

        yield return StartCoroutine(FlashRed());

        yield return new WaitForSeconds(respawnDelay);

        CharacterController controller = player.GetComponent<CharacterController>();
        PlayerSpawn spawn = player.GetComponent<PlayerSpawn>();

        if (controller != null)
            controller.enabled = false;

        if (spawn != null && spawn.currentSpawn != null)
            player.transform.position = spawn.currentSpawn.position;

        if (controller != null)
            controller.enabled = true;

        isRespawning = false;
    }

    IEnumerator FlashRed()
    {
        if (damageFlash == null)
            yield break;

        damageFlash.color = new Color(1, 0, 0, flashAlpha);
        yield return new WaitForSeconds(flashDuration);
        damageFlash.color = new Color(1, 0, 0, 0);
    }

    void CreateFlashCanvas()
    {
        if (damageFlash != null) return;

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
        damageFlash.rectTransform.offsetMin = Vector2.zero;
        damageFlash.rectTransform.offsetMax = Vector2.zero;
    }
}