using UnityEngine;
using UnityEngine.UI;

public class TopResult : MonoBehaviour
{
    [SerializeField] private Bird _bird;    
    [SerializeField] private CanvasGroup _topResult;

    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _lastScoreText;
    [SerializeField] private Image _medalContainer;
    [SerializeField] private Button _showResultsButton;

    [Header("Medal Templates")]
    [SerializeField] private Sprite _bronzeMedal;
    [SerializeField] private Sprite _silverMedal;
    [SerializeField] private Sprite _goldMedal;
    [SerializeField] private Sprite _platinumMedal;
    [SerializeField] private Sprite _emptyMedal;

    private int _bestScore;
    private int _lastScore;


    private void OnEnable()
    {
        _bird.UpdateResult += OnUpdateResult;
        _showResultsButton.onClick.AddListener(OnResultButtonClick);
    }

    private void OnDisable()
    {
        _bird.UpdateResult -= OnUpdateResult;
        _showResultsButton.onClick.RemoveListener(OnResultButtonClick);
    }

    private void Start()
    {
        _bestScore = 0;
        _lastScore = 0;
        Close();
    }

    public void Open()
    {
        _topResult.alpha = 1;
    }

    public void Close()
    {
        _topResult.alpha = 0;
    }

    private void OnUpdateResult(int lastScore)
    {
        _lastScore = lastScore;

        if (_lastScore > _bestScore)
            _bestScore = _lastScore;

        UpdatePanel();
    }

    private void UpdatePanel()
    {
        if (_bestScore >= 1000)
            _medalContainer.sprite = _platinumMedal;
        else if (_bestScore >= 500)
            _medalContainer.sprite = _goldMedal;
        else if (_bestScore >= 100)
            _medalContainer.sprite = _silverMedal;
        else if (_bestScore >= 10)
            _medalContainer.sprite = _bronzeMedal;
        else
            _medalContainer.sprite = _emptyMedal;

        _bestScoreText.text = _bestScore.ToString();
        _lastScoreText.text = _lastScore.ToString();
    }

    private void OnResultButtonClick()
    {
        if (_topResult.alpha == 0)
        {
            Open();
            UpdatePanel();
        }
        else
            Close();        
    }
}
