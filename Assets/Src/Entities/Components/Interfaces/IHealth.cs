namespace Asteroids.Interfaces
{
    public interface IHealth
    {
        bool IsDead { get; }
        
        void AddDamage(float damage);
    }
}