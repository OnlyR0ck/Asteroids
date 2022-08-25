using System;
using Game.Level;
using Game.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class PlayerService : IService
    {
        private readonly GameObjectsService gameObjectsService;
        
        public event Action OnPlayerKilled;

        public PlayerController Player { get; private set; }


        public PlayerService(GameObjectsService gameObjectsService) => 
            this.gameObjectsService = gameObjectsService;

        
        public void Init()
        {
            
        }

        public void SpawnPlayer(LevelController level)
        {
            Player = gameObjectsService.CreatePlayer().GetComponent<PlayerController>();
            Player.gameObject.layer = LayerMaskHandler.Player;
            
            Player.transform.SetParent(level.PlayerRoot);
            Player.transform.localPosition = Vector3.zero;
            Player.transform.localRotation = Quaternion.identity;

            Player.OnDamaged += Player_OnDamaged;

            Player.gameObject.SetActive(true);
        }

        public void Stop() => Object.Destroy(Player.gameObject);

        private void Player_OnDamaged()
        {
            OnPlayerKilled?.Invoke();
            Player.OnDamaged -= Player_OnDamaged;
        }
    }
}