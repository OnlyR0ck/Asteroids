using System;
using System.Collections.Generic;
using Infrastructure.FSM;
using UI.Screens;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class UIScreenService : IService
    {
        private readonly ServicesHub servicesHub;
    
        private readonly Dictionary<Type, BaseScreen> screens;
    
        private BaseScreen currentScreen;


        public void Init()
        {
        }

    
        public UIScreenService(ServicesHub servicesHub)
        {
            screens = new Dictionary<Type, BaseScreen>();

            ResourcesService resourcesService = servicesHub.Resolve<ResourcesService>();
            this.servicesHub = servicesHub;

            foreach (BaseScreen screen in resourcesService.Ui.Screens)
            {
                screens.Add(screen.GetType(), screen);
            }
        }

    
    
        public void ShowScreen<TScreenType>() where TScreenType : BaseScreen
        {
            currentScreen?.Close();
        
            BaseScreen newScreenPrefab = screens[typeof(TScreenType)];
            BaseScreen newScreen = Object.Instantiate(newScreenPrefab, GameSceneReferencesService.GuiScreensRoot);
            currentScreen = newScreen;

            newScreen.Init(servicesHub);
        }
    }
}