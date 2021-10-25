using UnityEngine;

namespace Bridge
{
    public sealed class TransformMove : IMove
    {
        public void Move()
        {
            Debug.Log("Transform Move");
        }
    }
}
