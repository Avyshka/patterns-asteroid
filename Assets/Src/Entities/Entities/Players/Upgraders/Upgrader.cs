using Asteroids.Entities.Entities.Players.Enums;
using Asteroids.Players.Views;

namespace Asteroids.Entities.Entities.Players.Upgraders
{
    public class Upgrader
    {
        protected PlayerView Player;
        private Upgrader _nextUpgrader;

        public Upgrader(PlayerView player)
        {
            Player = player;
        }

        public void Add(Upgrader upgrader)
        {
            if (_nextUpgrader == null)
            {
                _nextUpgrader = upgrader;
            }
            else
            {
                _nextUpgrader.Add(upgrader);
            }
        }

        public virtual void MakeUpgrade(PlayerUpgrade playerUpgrade)
        {
            _nextUpgrader?.MakeUpgrade(playerUpgrade);
        }
    }
}