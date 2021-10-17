using UnityEngine;

namespace Decorator
{
    public abstract class ModificationWeapon
    {
        protected GameObject Modificator;

        public void ApplyModification(Weapon weapon)
        {
            if (Modificator == null)
            {
                AddModification(weapon);
            }
            else
            {
                RemoveModification(weapon);
            }
        }

        protected abstract void AddModification(Weapon weapon);
        protected abstract void RemoveModification(Weapon weapon);
    }
}