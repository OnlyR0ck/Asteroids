using System;
using System.Collections.Generic;
using Infrastructure.FSM;
using UI.Screens;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class UIScreenService : IInitializable, IUIScreenService
    {
        private readonly GameStateMachine gameStateMachine;

        private readonly Dictionary<Type, BaseScreen> screens;
        private readonly List<BaseScreen> screensData;

        private BaseScreen currentScreen;

        

        [Inject]
        public UIScreenService(IResourcesService resourcesService, GameStateMachine gameStateMachine)
        {
            screensData = resourcesService.Ui.Screens;
            screens = new Dictionary<Type, BaseScreen>();
            
            this.gameStateMachine = gameStateMachine;
        }

        public void Initialize() => LoadScreensData();


        public void ShowScreen<TScreenType>() where TScreenType : BaseScreen
        {
            if(currentScreen != null)
                currentScreen.Close();
        
            BaseScreen newScreenPrefab = screens[typeof(TScreenType)];
            BaseScreen newScreen = Object.Instantiate(newScreenPrefab, GameSceneReferencesService.GuiScreensRoot);
            currentScreen = newScreen;

            newScreen.Init(gameStateMachine);
        }

        private void LoadScreensData()
        {
            foreach (BaseScreen screen in screensData)
            {
                screens.Add(screen.GetType(), screen);
            }
        }
    }
}