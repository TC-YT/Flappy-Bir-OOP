using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameStarted = false;
    private bool _isGameOver = false;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _isGameStarted = false;
        _isGameOver = false;
        Time.timeScale = 0f; 
    }

    public void StartGame()
    {
        if (_isGameStarted) return;

        _isGameStarted = true;

        UIManager.Instance.HideStartPanel();
        UIManager.Instance.HideGameOverPanel();

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (_isGameOver) return;

        _isGameOver = true;

        Time.timeScale = 0f;

        int finalScore = ScoreManager.Instance.GetCurrentScore();

        UIManager.Instance.ShowGameOverPanel(finalScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        _isGameStarted = false;
        _isGameOver = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameStarted()
    {
        return _isGameStarted;
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }
}