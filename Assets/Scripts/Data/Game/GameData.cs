using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.Game
{
    [CreateAssetMenu(menuName = "Data/Game/Main", fileName = "Data_MainGame")]
    public class GameData : ScriptableObject
    {
        #region Nested Types

        [Serializable]
        public class Player
        {
            [SerializeField] private GameObject playerPrefab;
            [SerializeField] private float speed;
            [SerializeField] private float rotationSpeed;
            [SerializeField] private float lasersCooldown;
            [SerializeField] private int lasersShoots;
            [SerializeField] private float bulletSpeed;


            private Player()
            {
            }


            public int LasersShoots => lasersShoots;

            public float LasersCooldown => lasersCooldown;

            public float Speed => speed;

            public float BulletSpeed => bulletSpeed;

            public GameObject PlayerPrefab => playerPrefab;

            public float RotationSpeed => rotationSpeed;
        }

        [Serializable]
        public class Enemies
        {
            [Space] [SerializeField] private UFOs ufoSettings;

            [Space] [SerializeField] private Asteroids asteroidsSettings;

            private Enemies()
            {
            }

            [Serializable]
            public class UFOs
            {
                [SerializeField] private GameObject UFOPrefab;
                [SerializeField] private Vector2 speedRange;
                [SerializeField] private float bulletSpeed;
                [SerializeField] private float reloadSpeed;

                [SerializeField, Range(0, 1f)] private float spawnChance;
                [SerializeField] private int pointsForDestroy;



                public GameObject UfoPrefab => UFOPrefab;

                public Vector2 SpeedRange => speedRange;

                public float BulletSpeed => bulletSpeed;

                public float ReloadSpeed => reloadSpeed;

                public float SpawnChance => spawnChance;

                public int PointsForDestroy => pointsForDestroy;
            }



            [Serializable]
            public class Asteroids
            {
                [SerializeField] private GameObject asteroidPrefab;
                [SerializeField] private GameObject asteroidPiecePrefab;
                [SerializeField] private Vector2 destroyedPiecesCount;
                [SerializeField] private Vector2 speedRange;
                [SerializeField] private float piecesSpeedMultiplier;
                [FormerlySerializedAs("spawnSpeed")] [SerializeField] private float spawnDelay;
                [SerializeField] private int pointsForDestroy;


                public GameObject AsteroidPrefab => asteroidPrefab;

                public Vector2 DestroyedPiecesCount => destroyedPiecesCount;

                public Vector2 SpeedRange => speedRange;

                public float PiecesSpeedMultiplier => piecesSpeedMultiplier;

                public float SpawnDelay => spawnDelay;

                public int PointsForDestroy => pointsForDestroy;
                public GameObject AsteroidPiecePrefab => asteroidPiecePrefab;
            }


            public UFOs UfoSettings => ufoSettings;

            
            public Asteroids AsteroidsSettings => asteroidsSettings;
        }

        #endregion

        [SerializeField] private GameObject levelPrefab;

        [Space, Header("Player")] [SerializeField]
        private Player playerSettings;

        [Space, Header("Enemies")] [SerializeField]
        private Enemies enemiesSettings;


        public Player PlayerSettings => playerSettings;

        public Enemies EnemiesSettings => enemiesSettings;

        public GameObject LevelPrefab => levelPrefab;
    }
}