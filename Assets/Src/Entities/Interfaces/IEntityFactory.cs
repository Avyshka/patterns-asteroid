using Asteroids.Entities.Enums;
using Asteroids.Interfaces;

namespace Asteroids.Entities.Interfaces
{
    public interface IEntityFactory
    {
        IUpdatable Create(EntityTypes type);
    }
}