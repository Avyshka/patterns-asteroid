using UnityEngine;

namespace Bridge
{
    public sealed class TeleportMove : IMove
    {
        public void Move()
        {
            Debug.Log("Teleport Move");
        }
    }
}
