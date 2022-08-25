using System;
using System.Collections.Generic;
using Infrastructure.FSM;
using Infrastructure.GameRunner;

namespace Infrastructure.Services
{
    public class ServicesHub
    {
        private Dictionary<Type, IService> servicesContainer;

        private static ServicesHub servicesHub;
        public static ServicesHub Container => servicesHub;

        public void Init(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner)
        {
            servicesContainer = new Dictionary<Type, IService>();
            
            servicesHub = this;
            servicesHub
                .RegisterService(new ResourcesService())
                .RegisterService(new InputService())
                .RegisterService(new ProgressService())

                .RegisterService(new GameObjectsService(
                    servicesHub.Resolve<ResourcesService>()))

                .RegisterService(new GameService(
                    servicesHub.Resolve<GameObjectsService>(),
                    servicesHub.Resolve<EnemiesService>(),
                    servicesHub.Resolve<PlayerService>()))

                .RegisterService(new UIScreenService(
                    servicesHub,
                    gameStateMachine))

                .RegisterService(new PlayerService( 
                    servicesHub.Resolve<GameObjectsService>()))
                
                .RegisterService(new EnemiesService(
                    coroutineRunner,
                    servicesHub.Resolve<GameObjectsService>(),
                    servicesHub.Resolve<ResourcesService>()));
        }


        public TServiceType Resolve<TServiceType>()
        {
            Type serviceType = typeof(TServiceType);
            IService service = servicesContainer[serviceType];

            if (service == null)
            {
                throw new NullReferenceException($"Service with provided type {nameof(TServiceType)} not found");
            }

            return (TServiceType) service;
        }

    
        private ServicesHub RegisterService<TServiceType>(TServiceType service) where TServiceType : class, IService 
        {
            servicesContainer.Add(typeof(TServiceType), service);
            return this;
        }
    }
}