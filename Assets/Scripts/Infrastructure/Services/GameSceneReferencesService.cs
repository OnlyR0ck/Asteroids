using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameSceneReferencesService : MonoBehaviour, IInitializable
    
    {
        #region Fields

        [Header("Roots")]
        [SerializeField] private Transform gameRoot;
        [SerializeField] private Canvas guiRoot;
        [SerializeField] private Transform guiScreensRoot;

        [Header("Cameras")]
        [SerializeField] private Camera gameCamera;

        #endregion



        #region Properties

        public static Transform GameRoot { get; private set; }
        public static Canvas GuiRoot { get; private set; }

        public static Transform GuiScreensRoot { get; private set; }
        public static Camera GuiCamera { get; private set; }

        #endregion



        #region Public methods

        public void Init()
        {
            GameRoot = gameRoot;
            GuiRoot = guiRoot;

            GuiScreensRoot = guiScreensRoot;

            GuiCamera = gameCamera;
        }

        #endregion

        public void Initialize()
        {
            GameRoot = gameRoot;
            GuiRoot = guiRoot;

            GuiScreensRoot = guiScreensRoot;

            GuiCamera = gameCamera;
        }
    }
}