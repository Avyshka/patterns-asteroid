using UnityEngine;

namespace Bridge
{
    public sealed class FlyMove : IMove
    {
        public void Move()
        {
            Debug.Log("Fly Move");
        }
    }
}
