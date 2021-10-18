using Asteroids.Entities.Entities.Players.Enums;
using Asteroids.Players.Views;

namespace Asteroids.Entities.Entities.Players.Upgraders
{
    public class HealthUpgrader : Upgrader
    {
        private readonly float _health;

        public HealthUpgrader(PlayerView player, float health) : base(player)
        {
            _health = health;
        }

        public override void MakeUpgrade(PlayerUpgrade playerUpgrade)
        {
            if (playerUpgrade == PlayerUpgrade.Health)
            {
                Player.Health.UpgradeHealth(_health);
            }
            else
            {
                base.MakeUpgrade(playerUpgrade);
            }
        }
    }
}