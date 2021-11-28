using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public UnityAction RestartButtonClick;

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
