using Asteroids.Enemies.Models;
using Asteroids.Enemies.Views;
using Asteroids.Interfaces;

namespace Asteroids.Enemies.Controllers
{
    public class EnemyController : IUpdatable
    {
        private readonly EnemyModel _model;
        private readonly Enemy _view;

        public EnemyController(EnemyModel model, Enemy view)
        {
            _model = model;
            _view = view;
            // _view.SetModel(_model);
        }

        public void OnUpdate(float deltaTime)
        {
            _view.OnUpdate(deltaTime);
        }
    }
}