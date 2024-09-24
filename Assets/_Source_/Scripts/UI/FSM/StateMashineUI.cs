using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMashineUI : MonoBehaviour
{
    [SerializeField][SerializeInterface(typeof(IGameView))] private GameObject _gameUI;
    [SerializeField][SerializeInterface(typeof(IGameView))] private GameObject _menuUI;
    [SerializeField][SerializeInterface(typeof(IGameView))] private GameObject _gameOverUI;

    private GameUIState _currentState;
    private Dictionary<Type, GameUIState> _states;

    private void Awake()
    {
        //Initialize();
    }

    public void EnterIn<TState>()
            where TState : GameUIState
    {
        if (_states.TryGetValue(typeof(TState), out GameUIState state))
        {
            _currentState?.Close();
            _currentState = state;
            _currentState.Open();
        }
    }

    private void Initialize()
    {
        _states = new Dictionary<Type, GameUIState>()
        {
            [typeof(GameSceneUIState)] = new GameSceneUIState(_gameUI.GetComponent<IGameView>()),
            [typeof(GameMenuUIState)] = new GameMenuUIState(_menuUI.GetComponent<IGameView>()),
            [typeof(GameOverUIState)] = new GameOverUIState(_gameOverUI.GetComponent<IGameView>()),
        };

        EnterIn<GameSceneUIState>();
    }
}