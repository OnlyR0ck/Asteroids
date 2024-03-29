﻿using System.Collections;
using Data.Game;
using Game.Player;
using Infrastructure.Services;
using UnityEngine;
using Utilities;

namespace Game.Enemies
{
    public class UfoWeaponController : WeaponControllerBase
    {
        private GameData.Enemies.UFOs ufoSettings;


        private void Awake()
        {
            base.Awake();

            ufoSettings = resourcesService.GameData.EnemiesSettings.UfoSettings;
            StartCoroutine(Coroutine_Shoot());
        }


        private IEnumerator Coroutine_Shoot()
        {
            while (true)
            {
                SpawnProjectile();
                yield return new WaitForSeconds(ufoSettings.ReloadDelay);
            }
        }

    
        private void SpawnProjectile()
        {
            GameObject projectile = gameObjectsService.GetPooledObject(PooledObjectType.Bullet);
        
            projectile.transform.position = transform.forward + Vector3.forward;
            projectile.transform.rotation = Quaternion.identity;
            projectile.layer = LayerMaskHandler.EnemiesLayer;
        
            projectile.SetActive(true);
        }
    }
}