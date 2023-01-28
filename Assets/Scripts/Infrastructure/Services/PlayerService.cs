using System;
using Game.Level;
using Game.Player;
using UnityEngine;
using Utilities;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class PlayerService : IService, IPlayerService
    {
        private readonly IGameObjectsService gameObjectsService;
        private PlayerController _player;

        public event Action OnPlayerKilled;

        public IPlayer Player { get; private set; }


        [Inject]
        public PlayerService(IGameObjectsService gameObjectsService) => 
            this.gameObjectsService = gameObjectsService;

        
        public void Init()
        {
            
        }

        public void SpawnPlayer(LevelController level)
        {
            _player = gameObjectsService.CreatePlayer().GetComponent<PlayerController>();
            Player = _player;
            
            _player.gameObject.layer = LayerMaskHandler.Player;
            
            _player.transform.SetParent(level.PlayerRoot);
            _player.transform.localPosition = Vector3.zero;
            _player.transform.localRotation = Quaternion.identity;

            _player.OnDamaged += Player_OnDamaged;

            _player.gameObject.SetActive(true);
        }

        public void Stop() => Object.Destroy(_player.gameObject);

        private void Player_OnDamaged()
        {
            OnPlayerKilled?.Invoke();
            _player.OnDamaged -= Player_OnDamaged;
        }
    }
}