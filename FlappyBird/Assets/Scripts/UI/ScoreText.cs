using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private Text _scoreText;    

    private void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _bird.UpdateScore += OnUpdateScore;
    }

    private void OnDisable()
    {
        _bird.UpdateScore -= OnUpdateScore;
    }

    private void OnUpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
