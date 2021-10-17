using System;
using Asteroids.Entities.Entities.Weapons.Interfaces;
using Asteroids.Interfaces;
using Asteroids.Players.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids.Players.Views
{
    [Serializable]
    public sealed class PlayerView : MonoBehaviour, IDamaged
    {
        public event Action PrepareToDestroy;

        private Ship _ship;
        private CorrectMoveTransform _correctMove;
        private IHealth _health;
        private Damage _damage;
        private Rigidbody _rigidbody;
        private IWeapon _weapon;

        public void Init(PlayerModel model, IWeapon weapon)
        {
            _rigidbody = GetComponent<Rigidbody>();
            var moveTransform = new AccelerationMove(_rigidbody, model.Speed, model.Acceleration);
            var rotation = new RotationTransform(_rigidbody, model.RotationSpeed);
            _ship = new Ship(moveTransform, rotation);
            _correctMove = new CorrectMoveTransform(_rigidbody);
            _health = new Health(model.Hp);
            _damage = new Damage();
            _weapon = weapon;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButton("Fire1"))
            {
                _weapon.Fire(transform);
            }
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }

            _ship.Rotate(Input.GetAxis("Horizontal"), deltaTime);
            _ship.Move(Input.GetAxis("Vertical"), deltaTime);
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
            if (other.gameObject.GetComponent<Bullet>())
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