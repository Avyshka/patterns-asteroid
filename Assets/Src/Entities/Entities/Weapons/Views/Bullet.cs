using System;
using Asteroids.Interfaces;
using Asteroids.Players.Views;
using Asteroids.Weapons.Models;
using UnityEngine;

namespace Asteroids.Weapons.Views
{
    public class Bullet : MonoBehaviour, IDamaged
    {
        public event Action PrepareToDestroy;

        private Rigidbody _rigidbody;
        private MoveTransform _moveTransform;
        private Damage _damage;

        public void Init(BulletModel model)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _moveTransform = new MoveTransform(_rigidbody, model.Speed);
            _damage = new Damage(model.Damage);
        }

        public void OnUpdate(float deltaTime)
        {
            _moveTransform.Move(1, deltaTime);
        }

        private void OnBecameInvisible()
        {
            PrepareToDestroy?.Invoke();
        }

        public void GetDamage(float damage)
        {
            PrepareToDestroy?.Invoke();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerView>())
            {
                return;
            }

            if (other.gameObject.TryGetComponent(out IDamaged damageComponent))
            {
                damageComponent.GetDamage(_damage.Hit);
            }
        }
    }
}