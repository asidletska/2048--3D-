using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    private float timeOnLine = 0f;
    public bool isOnLine = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnLine = true;
            timeOnLine = 0f;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeOnLine += Time.deltaTime;

            if (timeOnLine >= 1f)
            {
                ShowLose();
            }
        }
    }
    public void ShowLose()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnLine = false;
            timeOnLine = 0f;
        }
    }

}
