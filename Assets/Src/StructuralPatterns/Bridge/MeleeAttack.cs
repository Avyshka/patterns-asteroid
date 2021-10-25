using UnityEngine;

namespace Bridge
{
    public sealed class MeleeAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Melee Attack");
        }
    }
}
