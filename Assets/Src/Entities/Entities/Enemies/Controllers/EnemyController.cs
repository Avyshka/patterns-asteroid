using Asteroids.Enemies.Models;
using Asteroids.Enemies.Views;
using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids.Enemies.Controllers
{
    public class EnemyController : IUpdatable
    {
        private readonly EnemyModel _model;
        private readonly Enemy _view;
        
        public bool IsDead => _model.IsDead;
        public GameObject View => _view.gameObject;

        public EnemyController(EnemyModel model, Enemy view)
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