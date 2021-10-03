using Asteroids.Interfaces;
using Asteroids.Players.Models;

namespace Asteroids.Players.Interfaces
{
    public interface IPlayerView : IUpdatable
    {
        void SetModel(PlayerModel model);
    }
}