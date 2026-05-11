using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float invincibleTime = 1.5f;
    bool isInvincible = false;
    Image damageFlash;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        CheckpointManager.lastCheckpoint = transform.position;

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
        // disable controller before teleporting
        controller.enabled = false;
        transform.position = CheckpointManager.lastCheckpoint;
        controller.enabled = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}