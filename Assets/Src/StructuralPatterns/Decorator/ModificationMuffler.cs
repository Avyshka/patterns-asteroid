using UnityEngine;

namespace Decorator
{
    public sealed class ModificationMuffler : ModificationWeapon
    {
        protected override void AddModification(Weapon weapon)
        {
            Modificator = Object.Instantiate(
                Resources.Load<GameObject>(AssetPath.Modifications[ModificationWeaponType.Muffler]),
                weapon.MufflerPosition(), Quaternion.identity, weapon.transform);
            weapon.SetShotVolume(0.5f);
        }

        protected override void RemoveModification(Weapon weapon)
        {
            Object.Destroy(Modificator);
            weapon.SetShotVolume(1.0f);
        }
    }
}