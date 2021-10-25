using UnityEngine;

namespace Bridge
{
    public sealed class DistanceAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Distance Attack");
        }
    }
}
