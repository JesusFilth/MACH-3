using Reflex.Core;
using UnityEngine;

public class GameSceneDI : MonoBehaviour, IInstaller
{
    [SerializeField] private Helper _helper;
    [SerializeField] private BallPool _ballPool;
    [SerializeField] private Stats _stats;
    [SerializeField] private GameSession _session;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_helper, typeof(IGameHelper));
        containerBuilder.AddSingleton(_ballPool, typeof(IBallPool));
        containerBuilder.AddSingleton(_stats);
        containerBuilder.AddSingleton(_session);
    }
}
