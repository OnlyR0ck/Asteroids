using System.Collections;
using Data.Game;
using Game.Level;
using Infrastructure.GameRunner;
using Types.Pool;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
    public class EnemiesService : IEnemiesService
    {
        private readonly ICoroutineRunner coroutineRunner;
        private readonly GameObjectsService gameObjectsService;
        private readonly GameData.Enemies enemiesSettings;
        private LevelController level;
        private Coroutine spawnCoroutine;

        [Inject]
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
            
            //TODO: Positioning our enemies outside of the screen
            enemy.transform.SetParent(level.EnemiesRoot);
            
            yield return new WaitForSeconds(enemiesSettings.AsteroidsSettings.SpawnDelay);
        }
    }
}