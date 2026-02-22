using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private PlayerMoveView playerView;
    [SerializeField] private PlayerStats playerStats;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(playerStats);
        builder.RegisterComponent(playerView);
        builder.Register<PlayerMoveModel>(Lifetime.Singleton);
        builder.Register<IInputProvider, PlayerInputProvider>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerMovePresenter>();
    }
}
