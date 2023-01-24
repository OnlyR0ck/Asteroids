using System.Collections;
using Data.Game;
using Game.Level;
using Infrastructure.GameRunner;
using UnityEngine;
using Utilities;

namespace Infrastructure.Services
{
    public class EnemiesService : IService
    {
        private readonly ICoroutineRunner coroutineRunner;
        private readonly GameObjectsService gameObjectsService;
        private readonly GameData.Enemies enemiesSettings;
        private LevelController level;
        private Coroutine spawnCoroutine;

        public EnemiesService(ICoroutineRunner coroutineRunner, GameObjectsService gameObjectsService, ResourcesService resourcesService)
        {
            this.coroutineRunner = coroutineRunner;
            this.gameObjectsService = gameObjectsService;

            enemiesSettings = resourcesService.GameData.EnemiesSettings;
        }


        public void Init()
        {
            
        }


        public void StartSpawnEnemies(LevelController level)
        {
            this.level = level;
            spawnCoroutine = coroutineRunner.StartCoroutine(Coroutine_SpawnEntities());
        }


        public void StopSpawnEntities()
        {
            if (spawnCoroutine == null)
            {
                coroutineRunner.StopCoroutine(spawnCoroutine);
            }
        }

        private IEnumerator Coroutine_SpawnEntities()
        {
            GameObject enemy = Random.value > enemiesSettings.UfoSettings.SpawnChance ?
                gameObjectsService.GetPooledObject(PooledObjectType.Asteroid) :
                gameObjectsService.GetPooledObject(PooledObjectType.Ufo);
            
            enemy.transform.position = GetRandomPositionToSpawn();
            enemy.transform.rotation = Quaternion.Euler(Random.insideUnitCircle);
            enemy.transform.SetParent(level.EnemiesRoot);
            enemy.SetActive(true);
            
            yield return new WaitForSeconds(enemiesSettings.AsteroidsSettings.SpawnDelay);
        }


        private Vector3 GetRandomPositionToSpawn()
        {
            Vector2 position = Vector2.zero;
            Bounds screenBounds = ScreenBounds.ScreenBoundsBorder.bounds;

            if (Random.Range(0, 2) > 0)
            {
                position.x = Random.Range(screenBounds.min.x, screenBounds.max.x);
                position.y = Random.Range(0, 2) > 0 ? screenBounds.min.y : screenBounds.max.y;
            }
            else
            {
                position.y = Random.Range(screenBounds.min.y, screenBounds.max.y);
                position.x = Random.Range(0, 2) > 0 ? screenBounds.min.x : screenBounds.max.x;
            }

            return position;
        }
        
    }
}