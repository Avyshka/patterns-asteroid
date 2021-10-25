using Asteroids.Entities.Entities.Players.Enums;
using Asteroids.Players.Views;

namespace Asteroids.Entities.Entities.Players.Upgraders
{
    public class DamageUpgrader : Upgrader
    {
        private readonly float _damage;
        
        public DamageUpgrader(PlayerView player, float damage) : base(player)
        {
            _damage = damage;
        }

        public override void MakeUpgrade(PlayerUpgrade playerUpgrade)
        {
            if (playerUpgrade == PlayerUpgrade.Damage)
            {
                Player.Damage.UpgradeDamage(_damage);
            }
            else
            {
                base.MakeUpgrade(playerUpgrade);
            }
        }
    }
}