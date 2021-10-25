using System.Collections.Generic;
using UnityEngine;

namespace Bridge
{
    public sealed class BridgeTest : MonoBehaviour
    {
        private void Start()
        {
            var enemies = new List<Enemy>();
            enemies.Add(new Enemy(new MagicalAttack(), new TransformMove()));
            enemies.Add(new Enemy(new DistanceAttack(), new FlyMove()));
            enemies.Add(new Enemy(new MeleeAttack(), new TeleportMove()));

            foreach (var enemy in enemies)
            {
                enemy.Attack();
                enemy.Move();
            }
        }
    }
}