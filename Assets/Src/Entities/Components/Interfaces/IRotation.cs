namespace Asteroids.Interfaces
{
    public interface IRotation
    {
        float RotationSpeed { get; }
        void Rotate(float horizontal, float deltaTime);
    }
}