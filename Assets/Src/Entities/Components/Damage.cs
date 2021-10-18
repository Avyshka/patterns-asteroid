namespace Asteroids
{
    public class Damage
    {
        public float Hit { get; private set; }

        public Damage(float hit = 1)
        {
            Hit = hit;
        }

        public void UpgradeDamage(float damage)
        {
            Hit += damage;
        }
    }
}