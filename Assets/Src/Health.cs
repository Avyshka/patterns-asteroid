using Asteroids.Interfaces;

namespace Asteroids
{
    public class Health : IHealth
    {
        private float _hp;

        public bool IsDead => _hp <= 0;

        public Health(float hp)
        {
            _hp = hp;
        }

        public void AddDamage()
        {
            _hp--;
        }
    }
}