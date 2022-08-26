using Infrastructure.Services;
using UnityEngine;

public class PlayerWeaponController : WeaponControllerBase
{
    private InputService inputService;

    private const int LaserLenght = 1000;

    private void Awake()
    {
        base.Awake();
        
        inputService = hub.Resolve<InputService>();
    }


    private void OnEnable()
    {
        inputService.OnFirstFireAction += InputService_OnFirstFireAction;
        inputService.OnSecondFireAction += InputService_OnSecondFireAction;
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
    }

    private void ShowLaserVisual()
    {
        
    }
}

public interface IDestroyable
{
    void Destroy();
}