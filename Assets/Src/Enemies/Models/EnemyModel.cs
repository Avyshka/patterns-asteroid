using Asteroids.ScriptableObjects;

namespace Asteroids.Enemies.Models
{
    public class EnemyModel
    {
        private readonly EnemyData _enemyData;

        public EnemyModel(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public float RotationSpeed => _enemyData.RotationSpeed;
        public float Speed => _enemyData.Speed;
        public float Hp => _enemyData.Hp;
        public float Damage => _enemyData.Damage;
    }
}