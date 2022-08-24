using System;
using System.Collections.Generic;
using Infrastructure.FSM;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class ServicesHub
    {
        private Dictionary<Type, IService> servicesContainer;

        private ServicesHub servicesHub;

        public void Init(GameStateMachine gameStateMachine)
        {
            servicesHub = this;

            servicesContainer = new Dictionary<Type, IService>();
            servicesHub
                .RegisterService(new ResourcesService())
                .RegisterService(new InputService())
                .RegisterService(new ProgressService())
                
                //TODO: It's temporary solution, should find a better way to get reference to this service.
                .RegisterService(Object.FindObjectOfType<GameSceneReferencesService>())
                
                .RegisterService(new GameService(
                    servicesHub.Resolve<ResourcesService>()))
                
                .RegisterService(new UIScreenService(
                    servicesHub, 
                    gameStateMachine));
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