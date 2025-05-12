using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameManager gameManager;

    public void OnSettingsButtonHandler()
    {
        GameManager.isPaused = true;
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
    }
    public void OnContinueButtonHandler()
    {
        GameManager.isPaused = false;
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
    }
    public void OnRestartButtonHandler()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
