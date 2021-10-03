using Asteroids.Interfaces;
using Asteroids.Players.Interfaces;
using Asteroids.Players.Models;

namespace Asteroids.Players.Controllers
{
    public class PlayerController : IUpdatable
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;

        public PlayerController(PlayerModel model, IPlayerView view)
        {
            _model = model;
            _view = view;
            _view.SetModel(_model);
        }

        public void OnUpdate(float deltaTime)
        {
            _view.OnUpdate(deltaTime);
        }
    }
}