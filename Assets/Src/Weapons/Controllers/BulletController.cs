using Asteroids.Interfaces;
using Asteroids.Weapons.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids.Weapons.Controllers
{
    public class BulletController : IUpdatable
    {
        private readonly BulletModel _model;
        private readonly Bullet _view;

        public bool IsDead => _model.IsDead;
        public GameObject View => _view.gameObject;
        
        public BulletController(BulletModel model, Bullet view)
        {
            _model = model;
            _view = view;
            _view.Init(_model);
            _view.PrepareToDestroy += PrepareToDestroy;
        }

        private void PrepareToDestroy()
        {
            _model.IsDead = true;
        }

        public void OnUpdate(float deltaTime)
        {
            _view.OnUpdate(deltaTime);
        }
    }
}