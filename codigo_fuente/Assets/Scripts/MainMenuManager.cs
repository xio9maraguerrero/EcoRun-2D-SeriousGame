using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject creditsPanel;   // lo usaremos para los créditos

    private void Start()
    {
        Time.timeScale = 1f;
        if (howToPlayPanel != null) howToPlayPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(false);
    }

    public void PlayGame() { SceneManager.LoadScene(1); }

    public void ShowHowToPlay() { if (howToPlayPanel != null) howToPlayPanel.SetActive(true); }
    public void HideHowToPlay() { if (howToPlayPanel != null) howToPlayPanel.SetActive(false); }

    public void ShowCredits() { if (creditsPanel != null) creditsPanel.SetActive(true); }
    public void HideCredits() { if (creditsPanel != null) creditsPanel.SetActive(false); }

    public void QuitGame() { Application.Quit(); }
}