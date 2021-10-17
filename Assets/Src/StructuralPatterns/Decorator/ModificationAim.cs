using UnityEngine;

namespace Decorator
{
    public class ModificationAim : ModificationWeapon
    {
        protected override void AddModification(Weapon weapon)
        {
            Modificator = Object.Instantiate(
                Resources.Load<GameObject>(AssetPath.Modifications[ModificationWeaponType.Aim]),
                weapon.AimPosition(), Quaternion.identity, weapon.transform);
        }

        protected override void RemoveModification(Weapon weapon)
        {
            Object.Destroy(Modificator);
        }
    }
}