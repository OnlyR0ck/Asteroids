using Game.Enemies.Asteroids;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Enemies
{
    public class AsteroidController : AsteroidControllerBase
    {
        [SerializeField] private int pieceSpreadRange;
        
        
        private GameObjectsService gameObjectsService;

        private new void Awake()
        {
            base.Awake();

            gameObjectsService = hub.Resolve<GameObjectsService>();
        }
        
        public override void Destroy()
        {
            rewardService.AddScore(asteroidsSettings.PointsForDestroy);
            gameObject.SetActive(false);

            SpawnPieces();
        }

        private void SpawnPieces()
        {
            Vector2Int piecesCountRange = asteroidsSettings.DestroyedPiecesCount;
            int count = UnityEngine.Random.Range(piecesCountRange.x, piecesCountRange.y);

            for (int i = 0; i < count; i++)
            {
                GameObject piece = gameObjectsService.GetPooledObject(PooledObjectType.AsteroidPiece);
                piece.transform.position = transform.position;
                piece.transform.rotation = transform.rotation;
                
                piece.transform.Rotate(0.0f,0.0f, UnityEngine.Random.Range(-pieceSpreadRange, pieceSpreadRange));
                piece.GetComponent<AsteroidMovement>().SetSpeedMultiplier(asteroidsSettings.PiecesSpeedMultiplier);
                piece.gameObject.SetActive(true);
            }
        }
    }
    
}