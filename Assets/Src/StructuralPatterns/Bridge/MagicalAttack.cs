using UnityEngine;

namespace Bridge
{
    public sealed class MagicalAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Magical Attack");
        }
    }
}
