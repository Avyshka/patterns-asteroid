using System;
using Asteroids.Entities.Entities.Weapons.Weapons;
using Asteroids.Interfaces;
using Asteroids.Players.Models;
using Asteroids.Players.Views;
using Src.Entities.Interfaces;
using UnityEngine;

namespace Asteroids.Players.Controllers
{
    public class PlayerController : IUpdatable, IFixedUpdatable
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;
        private readonly WeaponWithReload _weaponWithReload;

        public bool IsDead => _model.IsDead;
        public GameObject View => _view.gameObject;
        
        public event Action<Transform> AddBullet;
        
        public PlayerController(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;

            var weapon = new Weapon();
            weapon.Shoot += OnShoot;

            _weaponWithReload = new WeaponWithReload(weapon, new WeaponReloader(0.05f));

            _view.Init(_model, _weaponWithReload);
            _view.PrepareToDestroy += PrepareToDestroy;
        }

        private void OnShoot(Transform transform)
        {
            AddBullet?.Invoke(transform);
        }

        private void PrepareToDestroy()
        {
            _model.IsDead = true;
        }

        public void OnUpdate(float deltaTime)
        {
            _view.OnUpdate(deltaTime);
            _weaponWithReload.OnUpdate(deltaTime);
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _view.OnFixedUpdate(deltaTime);
        }
    }
}