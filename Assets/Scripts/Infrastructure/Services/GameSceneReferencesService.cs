using Infrastructure.Services;
using UnityEngine;

public class GameSceneReferencesService : MonoBehaviour, IService
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
}