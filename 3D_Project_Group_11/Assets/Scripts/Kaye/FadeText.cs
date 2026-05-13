using UnityEngine;
using System.Collections;
using TMPro;

public class FadeText : MonoBehaviour
{
    public float showTime = 3f;
    public float fadeDuration = 1f;

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(showTime);

        Color startColor = text.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - (t / fadeDuration);
            text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}