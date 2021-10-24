using Asteroids.ScriptableObjects;

namespace Asteroids.Weapons.Models
{
    public class BulletModel
    {
        private readonly BulletData _bulletData;

        public BulletModel(BulletData bulletData)
        {
            _bulletData = bulletData;
        }

        public float Speed => _bulletData.Speed;
        public float Damage => _bulletData.Damage;
        public bool IsDead { get; set; }
    }
}