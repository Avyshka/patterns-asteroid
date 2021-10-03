using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids.Enemies.Views
{
    public abstract class Enemy : MonoBehaviour, IUpdatable
    {
        private IHealth _health;

        public void DependencyInjectHealth(IHealth hp)
        {
            _health = hp;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_health.IsDead)
            {
                return;
            }

            _health.AddDamage();
            if (_health.IsDead)
            {
                Destroy(gameObject);
            }
        }
    }
}