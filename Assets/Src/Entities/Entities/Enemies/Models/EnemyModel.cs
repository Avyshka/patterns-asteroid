using Asteroids.Entities.Enums;
using Asteroids.ScriptableObjects;

namespace Asteroids.Enemies.Models
{
    public class EnemyModel
    {
        private readonly EnemyData _enemyData;

        public EnemyModel(EnemyData enemyData, EntityTypes type)
        {
            _enemyData = enemyData;
            Type = type;
        }

        public EntityTypes Type { get; }

        public float RotationSpeed => _enemyData.RotationSpeed;
        public float SpeedMin => _enemyData.SpeedMin;
        public float SpeedMax => _enemyData.SpeedMax;
        public float Hp => _enemyData.Hp;
        public float Damage => _enemyData.Damage;
        public float Score => _enemyData.Score;
        public bool IsDead { get; set; }
    }
}