using Asteroids.Entities.Entities.Weapons.Interfaces;
using UnityEngine;

namespace Asteroids.Entities.Entities.Weapons.Weapons
{
    public class WeaponWithReload : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly WeaponReloader _reloader;

        public WeaponWithReload(IWeapon weapon, WeaponReloader reloader)
        {
            _weapon = weapon;
            _reloader = reloader;
        }

        public void Fire(Transform transform)
        {
            if (_reloader.Unloaded)
            {
                return;
            }
            _weapon.Fire(transform);
            _reloader.StartReload();
        }

        public void OnUpdate(float delta)
        {
            if (_reloader.Unloaded)
            {
                _reloader.Countdown(delta);
            }
        }
    }
}