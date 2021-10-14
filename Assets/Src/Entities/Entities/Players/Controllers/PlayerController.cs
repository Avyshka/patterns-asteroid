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

        public bool IsDead => _model.IsDead;
        public GameObject View => _view.gameObject;
        
        public PlayerController(PlayerModel model, PlayerView view)
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
        
        public void OnFixedUpdate(float deltaTime)
        {
            _view.OnFixedUpdate(deltaTime);
        }
    }
}