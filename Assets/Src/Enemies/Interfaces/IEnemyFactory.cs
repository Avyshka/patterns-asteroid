using UnityEngine;

namespace Asteroids.Enemies.Interfaces
{
    public interface IEnemyFactory
    {
        GameObject Create(Health hp);
    }
}