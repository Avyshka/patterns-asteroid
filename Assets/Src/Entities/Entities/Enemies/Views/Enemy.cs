using System;
using Asteroids.Enemies.Models;
using Asteroids.Entities.Entities.Enemies.Interfaces;
using Asteroids.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Enemies.Views
{
    public abstract class Enemy : MonoBehaviour, IDamaged
    {
        public event Action PrepareToDestroy;

        private IHealth _health;
        private Damage _damage;
        private Rigidbody _rigidbody;
        private CorrectMoveTransform _correctMove;

        public void Init(EnemyModel model)
        {
            _rigidbody = GetComponent<Rigidbody>();

            _correctMove = new CorrectMoveTransform(_rigidbody, 5);
            _health = new Health(model.Hp);
            _damage = new Damage(model.Damage);

            transform.Translate(_correctMove.GetRandomPosition());

            _rigidbody.angularVelocity += Random.Range(-model.RotationSpeed, model.RotationSpeed) * Vector3.right;
            _rigidbody.transform.Rotate(Vector3.right * Random.Range(0.0f, 360.0f));
            _rigidbody.AddForce(_rigidbody.transform.forward * Random.Range(model.SpeedMin, model.SpeedMax) *
                                _rigidbody.mass);
        }
        public void Activate(ISpawn value)
        {
            value.Visit(this);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }

            _correctMove.CorrectMove();
        }

        public void GetDamage(float damage)
        {
            if (_health.IsDead)
            {
                return;
            }

            _health.AddDamage(damage);
            if (_health.IsDead)
            {
                PrepareToDestroy?.Invoke();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamaged damageComponent))
            {
                damageComponent.GetDamage(_damage.Hit);
            }
        }
    }
}