﻿using System;
using System.Collections.Generic;
using System.Threading;
using Asteroids.Pools.Interfaces;
using UnityEngine;

namespace Asteroids.Pools
{
    public sealed class ViewServices : IViewServices
    {
        private static readonly Lazy<ViewServices> _instance =
            new Lazy<ViewServices>(() => new ViewServices(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static ViewServices Instance => _instance.Value;

        private readonly Dictionary<string, ObjectPool> _viewCache = new Dictionary<string, ObjectPool>(12);

        private ViewServices()
        {
        }

        public GameObject Instantiate(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            return viewPool.Pop();
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}