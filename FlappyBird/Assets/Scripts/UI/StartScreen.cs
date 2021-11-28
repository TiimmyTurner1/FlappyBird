using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private Button _showResultsButton;

    public UnityAction PlayButtonClick;

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _showResultsButton.interactable = true;
        Button.interactable = true;
        Button.GetComponent<Image>().raycastTarget = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _showResultsButton.interactable = false;
        Button.interactable = false;
        Button.GetComponent<Image>().raycastTarget = false;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
