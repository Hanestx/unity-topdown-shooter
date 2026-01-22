using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.Pool
{
    public class ObjectPool<T> where T : Component, IPoolable
    {
        private readonly Stack<T> _pool = new();
        private readonly T _prefab;
        private readonly Transform _parent;

        public ObjectPool(T prefab, int initialSize, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = Object.Instantiate(_prefab, _parent);
                obj.gameObject.SetActive(false);
                _pool.Push(obj);
            }
        }

        public T Get()
        {
            T obj = _pool.Count > 0
                ? _pool.Pop()
                : Object.Instantiate(_prefab, _parent);

            obj.gameObject.SetActive(true);
            obj.OnSpawned();
            return obj;
        }

        public void Return(T obj)
        {
            obj.OnDespawned();
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }
}