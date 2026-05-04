using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
        {
            hoverSound.PlayOneShot(hoverSound.clip);
        }
    }
}
