using Data.Game;
using Game.Player;
using Infrastructure.Services;
using UnityEngine;

public class UfoMovementController : MonoBehaviour
{
    private PlayerService playerService;
    private ResourcesService resourcesService;
    private PlayerController player;
    private GameData.Enemies.UFOs ufoSettings;
    private float ufoSpeed;

    private void Awake()
    {
        ServicesHub hub = ServicesHub.Container;
        
        playerService = hub.Resolve<PlayerService>();
        resourcesService = hub.Resolve<ResourcesService>();

        player = playerService.Player;
        ufoSettings = resourcesService.GameData.EnemiesSettings.UfoSettings;
        ufoSpeed = Random.Range(ufoSettings.SpeedRange.x, ufoSettings.SpeedRange.y);
    }


    private void Update()
    {
        Vector2 currentDirection = player.transform.position - transform.position;
        transform.Translate(currentDirection * (ufoSpeed * Time.deltaTime) );
    }
}