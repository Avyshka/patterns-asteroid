using Asteroids.Enemies.Controllers;
using Asteroids.Enemies.Enums;

namespace Asteroids.Enemies.Interfaces
{
    public interface IEnemyFactory
    {
        EnemyController Create(EnemyTypes data);
    }
}