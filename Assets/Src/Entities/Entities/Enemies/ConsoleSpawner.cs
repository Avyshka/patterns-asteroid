using Asteroids.Enemies.Views;
using Asteroids.Entities.Entities.Enemies.Interfaces;
using UnityEngine;

namespace Asteroids.Entities.Entities.Enemies
{
    public class ConsoleSpawner : ISpawn
    {
        public void Visit(Enemy enemy)
        {
            Debug.Log($"{enemy.GetType().Name} spawned");
        }
    }
}