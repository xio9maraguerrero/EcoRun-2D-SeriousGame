using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("HUD")]
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject successMessage;
    [SerializeField] private float messageSeconds = 1.2f;

    [Header("Pantallas finales")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Puntos")]
    [SerializeField] private int pointsPerCorrect = 50;
    [SerializeField] private int pointsToWin = 250;

    private int lives, score;
    private bool ended;
    private Transform player;
    private Coroutine messageRoutine;

    private void Awake() { Instance = this; Time.timeScale = 1f; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lives = hearts.Length;
        if (winPanel != null) winPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (successMessage != null) successMessage.SetActive(false);
        UpdateHUD();
    }

    public void Deposit(WasteType binType)
    {
        if (ended) return;

        Camera cam = Camera.main;
        float rightEdge = cam.transform.position.x + cam.orthographicSize * cam.aspect;

        WasteItem target = null;
        foreach (WasteItem w in WasteItem.Active)
        {
            float x = w.transform.position.x;
            if (x < player.position.x || x > rightEdge) continue;
            if (target == null || x < target.transform.position.x) target = w;
        }
        if (target == null) return;

        bool correct = target.type == binType;
        Destroy(target.gameObject);

        if (correct)
        {
            score += pointsPerCorrect;
            UpdateHUD();
            ShowSuccess();
            if (score >= pointsToWin) EndGame(winPanel);
        }
        else LoseLife();
    }

    public void LoseLife()
    {
        if (ended) return;
        lives--;
        for (int i = 0; i < hearts.Length; i++) hearts[i].SetActive(i < lives);
        if (lives <= 0) EndGame(gameOverPanel);
    }

    private void ShowSuccess()
    {
        if (successMessage == null) return;
        if (messageRoutine != null) StopCoroutine(messageRoutine);
        messageRoutine = StartCoroutine(SuccessRoutine());
    }

    private IEnumerator SuccessRoutine()
    {
        successMessage.SetActive(true);
        yield return new WaitForSecondsRealtime(messageSeconds);
        successMessage.SetActive(false);
    }

    private void UpdateHUD()
    {
        if (pointsText != null) pointsText.text = "PUNTOS: " + score;
    }

    private void EndGame(GameObject panel)
    {
        ended = true;
        if (messageRoutine != null) StopCoroutine(messageRoutine);
        if (successMessage != null) successMessage.SetActive(false);
        if (panel != null) panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}