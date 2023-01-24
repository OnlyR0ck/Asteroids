using System;
using Data.Game;
using Game.Player;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class BulletController : WeaponBase
{
    private GameData.Player playerSettings;
    private CollisionHandler collisionHandler;

    private new void Awake()
    {
        base.Awake();

        playerSettings = resourcesService.GameData.PlayerSettings;
        collisionHandler = GetComponent<CollisionHandler>();
    }

    
    private void OnEnable()
    {
        collisionHandler.OnEnter += CollisionHandler_OnEnter;
    }

    
    private void OnDisable()
    {
        collisionHandler.OnEnter -= CollisionHandler_OnEnter;
    }


    private void Update() => transform.Translate(transform.up * (playerSettings.BulletSpeed * Time.deltaTime));

    
    
    private void CollisionHandler_OnEnter() => gameObject.SetActive(false);
}