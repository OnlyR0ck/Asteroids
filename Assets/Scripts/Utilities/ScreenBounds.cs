using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScreenBounds : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float teleportOffset = 0.2f;
        [SerializeField] private float cornerOffset = 1;
        
        private BoxCollider2D screenBoundsCollider;
        private Camera mainCamera;
        
        #endregion

        public static BoxCollider2D ScreenBoundsBorder { get; private set; }

        #region Unity Lifecycle

        private void Awake()
        {
            mainCamera = Camera.main;
            screenBoundsCollider = GetComponent<BoxCollider2D>();
            screenBoundsCollider.isTrigger = true;
        }


        private void Start()
        {
            RefreshBounds();
            ScreenBoundsBorder = screenBoundsCollider;
        }


        private void OnTriggerStay2D(Collider2D other)
        {
            if (AmIOutOfBounds(other.transform.position))
            {
                other.transform.position = CalculateWrappedPosition(other.transform.position);
            }
        }

        #endregion



        #region Public Methods

        public bool AmIOutOfBounds(Vector3 worldPosition) =>
            Mathf.Abs(worldPosition.x) > Mathf.Abs(screenBoundsCollider.bounds.min.x) ||
            Mathf.Abs(worldPosition.y) > Mathf.Abs(screenBoundsCollider.bounds.min.y);


        public Vector2 CalculateWrappedPosition(Vector2 worldPosition)
        {
            bool xBoundResult = 
                Mathf.Abs(worldPosition.x) > (Mathf.Abs(screenBoundsCollider.bounds.min.x) - cornerOffset);
            bool yBoundResult = 
                Mathf.Abs(worldPosition.y) > (Mathf.Abs(screenBoundsCollider.bounds.min.y) - cornerOffset);

            Vector2 signWorldPosition = 
                new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

            if (xBoundResult && yBoundResult)
            {
                return Vector2.Scale(worldPosition, Vector2.one * -1) 
                       + Vector2.Scale(new Vector2(teleportOffset, teleportOffset), 
                           signWorldPosition);
            }

            if (xBoundResult)
            {
                return new Vector2(worldPosition.x * -1, worldPosition.y) 
                       + new Vector2(teleportOffset * signWorldPosition.x, teleportOffset);
            }
            
            if (yBoundResult)
            {
                return new Vector2(worldPosition.x, worldPosition.y * -1) 
                       + new Vector2(teleportOffset, teleportOffset * signWorldPosition.y);
            }
            
            return worldPosition;
        }

        #endregion


        #region Private Methods

        private void RefreshBounds()
        {
            float height = mainCamera.orthographicSize * 2;
            screenBoundsCollider.size = new Vector2(mainCamera.aspect * height, height);
        }

        #endregion
    }
}
