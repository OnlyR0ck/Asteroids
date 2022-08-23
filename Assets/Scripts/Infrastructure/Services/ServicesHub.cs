using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class ServicesHub
    {
        private Dictionary<Type, IService> servicesContainer;
        private ServicesHub servicesHub;
        public void Init()
        {
            servicesHub = this;
            servicesContainer = new Dictionary<Type, IService>();

            servicesHub
                .RegisterService(new InputService())
                .RegisterService(new ProgressService())
                //TODO:
                .RegisterService(Object.FindObjectOfType<GameSceneReferencesService>());
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