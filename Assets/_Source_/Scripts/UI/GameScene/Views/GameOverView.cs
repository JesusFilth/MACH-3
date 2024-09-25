using Reflex.Attributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverView : MonoBehaviour, IGameView
{
    private CanvasGroup _canvasGroup;

    [Inject] private IRecordStorage _recordStorage;
    [Inject] private Stats _stats;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        BlockBallUsable.Instance.Unlock();
    }

    public void Show()
    {
        if (CheckForNewRecords())
            return;

        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        BlockBallUsable.Instance.Lock();
    }

    private bool CheckForNewRecords()
    {
        int hightRecord = _recordStorage.GetHightRecord();

        if (hightRecord < _stats.Score)
        {
            RecordModel newRecord = new RecordModel
            {
                Data = DateTime.Now.ToString(),
                Score = _stats.Score
            };

            _recordStorage.AddNewRecord(newRecord);

            SceneManager.LoadScene(GameSceneNames.Records);
            return true;
        }

        return false;
    }
}
