using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject settingsPanel;

    public void OnSettingsButtonHandler()
    {
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
    }
    public void OnContinueButtonHandler()
    {
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
    }
    public void OnRestartButtonHandler()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
