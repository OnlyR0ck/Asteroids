using Data.Game;
using Infrastructure.Services;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private ResourcesService resourcesService;
    private GameData.Player playerSettings;
    private InputService inputService;

    public void Init(ResourcesService resourcesService, InputService inputService)
    {
        this.inputService = inputService;
        this.resourcesService = resourcesService;
        
        playerSettings = resourcesService.GameData.PlayerSettings;
    }

    
    private void OnEnable()
    {
        inputService.OnMoveAction += InputService_OnMoveAction;
    }

    
    private void OnDisable()
    {
        inputService.OnMoveAction -= InputService_OnMoveAction;
    }

    
    private void InputService_OnMoveAction()
    {
        
    }
}