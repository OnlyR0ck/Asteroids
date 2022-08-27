using System.Collections;
using Data.Game;
using DG.Tweening;
using Infrastructure.Services;
using UnityEngine;
using Utilities;

namespace Game.Player
{
    public class PlayerWeaponController : WeaponControllerBase
    {
        private InputService inputService;
        private GameData.Player playerSettings;
        private int lasersCount;
        private Coroutine lasersCooldownCoroutine;
        private const float LaserVisibleTime = 0.2f;

        private const int LaserLenght = 1000;

        private void Awake()
        {
            base.Awake();
        
            inputService = hub.Resolve<InputService>();
            playerSettings = resourcesService.GameData.PlayerSettings;
        }


        private void OnEnable()
        {
            inputService.OnFirstFireAction += InputService_OnFirstFireAction;
            inputService.OnSecondFireAction += InputService_OnSecondFireAction;

            DOTween.Kill(this);
        }

    
        private void OnDisable() => inputService.OnFirstFireAction -= InputService_OnFirstFireAction;
    
    
        private void InputService_OnFirstFireAction() => BulletShot();

    
        private void InputService_OnSecondFireAction() => LaserShot();


        private void BulletShot()
        {
            GameObject bulletProjectile = gameObjectsService.GetPooledObject(PooledObjectType.PlayerBullet);
            bulletProjectile.transform.localPosition = transform.forward + Vector3.forward;
            bulletProjectile.transform.localRotation = Quaternion.identity;
        
            bulletProjectile.SetActive(true);
        }


        private void LaserShot()
        {
            if (lasersCount == 0)
            {
                return;
            }

            lasersCount--;
            
            ShowLaserVisual();
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, LaserLenght,
                LayerMaskHandler.EnemiesLayerMask, QueryTriggerInteraction.Collide);

            if (hits == null)
            {
                return;
            }

            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.TryGetComponent(out IDestroyable destroyable))
                {
                    destroyable.Destroy();
                }
            }

            //TODO:should check if running and exist.
            //TODO: Theory: variable can store reference, but coroutine have been completed
            
            lasersCooldownCoroutine ??= StartCoroutine(Coroutine_LaserReload());
        }

        private void ShowLaserVisual()
        {
            //TODO: mb variable will store reference to config, possible problem place
            
            LineRenderer laser = new LineRenderer();
            laser = playerSettings.LaserVisual;
            
            laser.SetPositions(new []{transform.forward, transform.forward * LaserLenght});
            laser.material.DOFade(0, LaserVisibleTime).OnComplete(() =>
            {
                
            }).SetId(this);
        }

        IEnumerator Coroutine_LaserReload()
        {
            while (lasersCount < playerSettings.LasersShoots)
            {
                yield return new WaitForSeconds(playerSettings.LasersCooldown);
                lasersCount++;
            }
        }
    }
}