using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winScreen.SetActive(true);

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}