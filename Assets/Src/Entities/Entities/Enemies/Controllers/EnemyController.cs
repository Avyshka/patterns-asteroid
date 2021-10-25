using System;
using Asteroids.Enemies.Models;
using Asteroids.Enemies.Views;
using Asteroids.Entities.Entities.Enemies;
using Asteroids.Entities.Enums;
using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids.Enemies.Controllers
{
    public class EnemyController : IUpdatable
    {
        private readonly EnemyModel _model;
        private readonly Enemy _view;
        
        public event Action<float> AddScores;
        public event Action<EntityTypes> AddDestroyedEnemy;
        
        public bool IsDead => _model.IsDead;
        public GameObject View => _view.gameObject;

        public EnemyController(EnemyModel model, Enemy view)
        {
            _model = model;
            _view = view;
            _view.Init(_model);
            _view.PrepareToDestroy += PrepareToDestroy;
            _view.Activate(new ConsoleSpawner());
        }

        private void PrepareToDestroy()
        {
            _model.IsDead = true;
            AddScores?.Invoke(_model.Score);
            AddDestroyedEnemy?.Invoke(_model.Type);
        }

        public void OnUpdate(float deltaTime)
        {
            _view.OnUpdate(deltaTime);
        }
    }
}