using System;
using System.Collections.Generic;
using System.ComponentModel;
using Data.Game;
using Types.Pool;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class GameObjectsService : IService, IGameObjectsService
    {
        private readonly Dictionary<PooledObjectType, List<GameObject>> pools;
        private readonly ResourcesService resourcesService;
        private readonly GameData gameData;

        [Inject]
        public GameObjectsService(ResourcesService resourcesService)
        {
            this.resourcesService = resourcesService;

            gameData = resourcesService.GameData;
        
            pools = new Dictionary<PooledObjectType, List<GameObject>>()
            {
                [PooledObjectType.Asteroid] = new(),
                [PooledObjectType.AsteroidPiece] = new(),
                [PooledObjectType.Ufo] = new()
            };
        }

    
    
        public void Init()
        {
        
        }


    
        public GameObject GetPooledObject(PooledObjectType key)
        {
            if (pools.ContainsKey(key))
            {
                IEnumerable<GameObject> pooledObjects = pools[key];
            
                GameObject freeObject = null;
                foreach (GameObject pooledObject in pooledObjects)
                {
                    if (!pooledObject.activeSelf)
                    {
                        freeObject = pooledObject;
                    }
                }

                if (freeObject == null)
                {
                    freeObject = Object.Instantiate(GetObjectByType(key));
                    pools[key].Add(freeObject);
                }

                return freeObject;
            }

            throw new InvalidEnumArgumentException($"There is no object with type {key}");
        }


        public GameObject CreatePlayer()
        {
            GameObject playerPrefab = gameData.PlayerSettings.PlayerPrefab;
            return Object.Instantiate(playerPrefab);
        }


        public GameObject CreateLevel()
        {
            GameObject levelPrefab = gameData.LevelPrefab;
            return Object.Instantiate(levelPrefab, GameSceneReferencesService.GameRoot);
        }

        public GameObject GetObjectByType(PooledObjectType type) =>
            type switch
            {
                PooledObjectType.Asteroid => gameData.EnemiesSettings.AsteroidsSettings.AsteroidPrefab,
                PooledObjectType.AsteroidPiece => gameData.EnemiesSettings.AsteroidsSettings.AsteroidPiecePrefab,
                PooledObjectType.Ufo => gameData.EnemiesSettings.UfoSettings.UfoPrefab,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
    }
}