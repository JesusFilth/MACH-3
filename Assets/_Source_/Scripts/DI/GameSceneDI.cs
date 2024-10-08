using Reflex.Core;
using UnityEngine;

public class GameSceneDI : MonoBehaviour, IInstaller
{
    [SerializeField] private Helper _helper;
    [SerializeField] private BallPool _ballPool;
    [SerializeField] private Pool _particlePool;
    [SerializeField] private Stats _stats;
    [SerializeField] private GameSession _session;
    [SerializeField] private StateMashineUI _stateMashineUI;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_helper, typeof(IGameHelper));
        containerBuilder.AddSingleton(_ballPool, typeof(IBallPool));
        containerBuilder.AddSingleton(_particlePool);
        containerBuilder.AddSingleton(_stats);
        containerBuilder.AddSingleton(_session);
        containerBuilder.AddSingleton(_stateMashineUI);
    }
}
