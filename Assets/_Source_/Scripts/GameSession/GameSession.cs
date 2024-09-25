using Reflex.Attributes;
using System.Collections;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private const float DelayForShowHelper = 1;

    [Inject] private Stats _stats;
    [Inject] private IGameHelper _helper;
    [Inject] private StateMashineUI _stateMashineUI;

    private void OnEnable()
    {
        _stats.GameEnded += GameOver;
    }

    private void OnDisable()
    {
        _stats.GameEnded -= GameOver;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(DelayForShowHelper);
        _helper.Show();
    }

    private void GameOver()
    {
        if (_helper.HasStep() == false)
            _stateMashineUI.EnterIn<GameOverUIState>();
    }
}