using Reflex.Attributes;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Inject] private Stats _stats;
    [Inject] private IGameHelper _helper;

    private void OnEnable()
    {
        _stats.GameEnded += GameOver;
    }

    private void OnDisable()
    {
        _stats.GameEnded -= GameOver;
    }

    private void GameOver()
    {
        if (_helper.HasStep() == false)
            Debug.Log("Game Over");
    }
}