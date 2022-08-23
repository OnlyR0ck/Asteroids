using System;
using System.Collections.Generic;
using Infrastructure.Services;
using UI.Screens;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class InputService : IService
    {
        public void Init()
        {
            
        }
    }
}

public class UIScreenService : IService
{
    private readonly Dictionary<Type, BaseScreen> screens;
    private BaseScreen currentScreen;

    public UIScreenService(ResourcesService resourcesService)
    {
        screens = new Dictionary<Type, BaseScreen>();
        
        foreach (BaseScreen screen in resourcesService.Ui.Screens)
        {
            screens.Add(screen.GetType(), screen);
        }
    }

    public void Init()
    {
        
    }

    public void ShowScreen<TScreenType>() where TScreenType : BaseScreen
    {
        currentScreen?.Close();
        BaseScreen newScreenPrefab = screens[typeof(TScreenType)];
        BaseScreen newScreen = Object.Instantiate(newScreenPrefab, GameSceneReferencesService.GuiScreensRoot);
    }
}