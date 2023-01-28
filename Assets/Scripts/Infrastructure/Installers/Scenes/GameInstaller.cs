using Infrastructure.Services;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallServices();
    }

    private void InstallServices()
    {
        Container.Bind<IEnemiesService>()
            .To<EnemiesService>()
            .AsSingle();

        Container.Bind<IGameObjectsService>()
            .To<GameObjectsService>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<GameSceneReferencesService>().AsSingle();

        Container.Bind<IGameService>()
            .To<GameService>()
            .AsSingle();
        
        Container.BindInterfacesTo<InputService>();
        Container.Bind<IInputService>()
            .To<InputService>()
            .AsSingle();

        Container.BindInterfacesTo<ResourcesService>();
        Container.Bind<IResourcesService>()
            .To<ResourcesService>()
            .AsSingle();

        Container.Bind<IPlayerService>()
            .To<PlayerService>()
            .AsSingle();

        Container.BindInterfacesTo<UIScreenService>();
        Container.Bind<IUIScreenService>()
            .To<UIScreenService>()
            .AsSingle();
    }
}
