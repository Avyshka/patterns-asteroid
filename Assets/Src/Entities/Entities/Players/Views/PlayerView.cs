using System;
using Asteroids.Entities.Entities.Weapons.Interfaces;
using Asteroids.Interfaces;
using Asteroids.Players.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids.Players.Views
{
    public sealed class PlayerView : MonoBehaviour, IDamaged
    {
        public event Action PrepareToDestroy;

        private Ship _ship;
        private CorrectMoveTransform _correctMove;
        private Rigidbody _rigidbody;
        private IWeapon _weapon;
        public Damage Damage { get; private set; }
        public IHealth Health { get; private set; }

        public void Init(PlayerModel model, IWeapon weapon)
        {
            _rigidbody = GetComponent<Rigidbody>();
            var moveTransform = new AccelerationMove(_rigidbody, model.Speed, model.Acceleration);
            var rotation = new RotationTransform(_rigidbody, model.RotationSpeed);
            _ship = new Ship(moveTransform, rotation);
            _correctMove = new CorrectMoveTransform(_rigidbody);
            Health = new Health(model.Hp);
            Damage = new Damage();
            _weapon = weapon;
        }

        public void OnUpdate(float deltaTime)
        {
            if (Health.IsDead)
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
            if (Health.IsDead)
            {
                return;
            }

            _ship.Rotate(Input.GetAxis("Horizontal"), deltaTime);
            _ship.Move(Input.GetAxis("Vertical"), deltaTime);
            _correctMove.CorrectMove();
        }

        public void GetDamage(float damage)
        {
            if (Health.IsDead)
            {
                return;
            }

            Health.AddDamage(damage);
            if (Health.IsDead)
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
                damageComponent.GetDamage(Damage.Hit);
            }
        }
    }
}