using UnityEngine;

namespace Asteroids.Interfaces
{
    public interface IUpdatable
    {
        bool IsDead { get; }
        GameObject View { get; }
        void OnUpdate(float deltaTime);
    }
}