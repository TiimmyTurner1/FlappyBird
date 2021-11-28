using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CanvasGroup _scoreText;
    [SerializeField] private TopResult _topResult;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;        
        _startScreen.Open();
        _gameOverScreen.Close();
        _topResult.Close();
        _scoreText.alpha = 0;        
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _topResult.Close();
        _scoreText.alpha = 1;
        StartGame();        
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _topResult.Close();
        _pipeSpawner.ResetSpawner();
        _scoreText.alpha = 1;
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
        _topResult.Open();
        _scoreText.alpha = 0;        
    }
}
