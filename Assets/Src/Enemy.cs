using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        private Health Health { get; set;  }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (Health.IsDead)
            {
                return;
            }

            Health.AddDamage();
            if (Health.IsDead)
            {
                Destroy(gameObject);
            }
        }
    }
}