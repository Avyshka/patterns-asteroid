using Asteroids.ScriptableObjects;

namespace Asteroids.Players.Models
{
    public class PlayerModel
    {
        private readonly PlayerData _playerData;

        public PlayerModel(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public float RotationSpeed => _playerData.RotationSpeed;
        public float Speed => _playerData.Speed;
        public float Acceleration => _playerData.Acceleration;
        public float Hp => _playerData.Hp;
        public bool IsDead { get; set; }
    }
}