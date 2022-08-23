using System;
using System.Collections.Generic;
using UI.Screens;
using UnityEngine;

namespace Data.UI
{
    [CreateAssetMenu(menuName = "Data/Ui/Screens",fileName = "Data_Screens")]
    public class ScreensData : ScriptableObject
    {
        [SerializeField] private List<BaseScreen> screens;

        public List<BaseScreen> Screens => screens;

        public TScreenType GetScreen<TScreenType>() where TScreenType : BaseScreen
        {
            foreach (BaseScreen screen in screens)
            {
                if (screen is TScreenType requiredScreen)
                {
                    return requiredScreen;
                }
            }

            throw new NullReferenceException($"Screen with provided type {nameof(TScreenType)} not found!");
        }
    }
}