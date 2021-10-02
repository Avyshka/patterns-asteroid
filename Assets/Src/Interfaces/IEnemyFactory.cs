namespace Asteroids.Interfaces
{
    public interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}