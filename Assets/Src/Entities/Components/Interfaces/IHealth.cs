namespace Asteroids.Interfaces
{
    public interface IHealth
    {
        bool IsDead { get; }

        void UpgradeHealth(float health);
        void AddDamage(float damage);
    }
}