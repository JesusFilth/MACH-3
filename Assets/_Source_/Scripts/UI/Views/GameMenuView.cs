using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameMenuView : MonoBehaviour, IGameView
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        BlockBallUsable.GetInstance().Unlock();
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        BlockBallUsable.GetInstance().Lock();
    }
}