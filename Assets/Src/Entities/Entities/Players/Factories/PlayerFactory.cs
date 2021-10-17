using Asteroids.Entities.Enums;
using Asteroids.Entities.Interfaces;
using Asteroids.Interfaces;
using Asteroids.Players.Controllers;
using Asteroids.Players.Models;
using Asteroids.Players.Views;
using Asteroids.Pools;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids.Entities.Entities.Players.Factories
{
    public sealed class PlayerFactory : IEntityFactory
    {
        public IUpdatable Create(EntityTypes type)
        {
            var data = Resources.Load<PlayerData>(EntityData.PlayerData.ToString());
            var player = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(EntityTypes.Player.ToString()));
            return new PlayerController(
                new PlayerModel(data),
                player.GetComponent<PlayerView>()
            );
        }
    }
}