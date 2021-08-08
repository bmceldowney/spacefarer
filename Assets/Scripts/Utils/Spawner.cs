using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Interface for objects to be spawned with the generic Spawner.
    /// </summary>
    public interface ISpawnable
    {
        Action<GameObject> Despawn { get; set; }
        GameObject GameObject { get; }
    }

    /// <summary>
    /// A generic game object spawner with pooling.
    /// </summary>
    /// <typeparam name="T">The type of ISpawnable object to spawn.</typeparam>
    public class Spawner<T> : Stack<T> where T : ISpawnable
    {
        GameObject _prefab;
        Transform _parent;
        bool _worldSpace;

        /// <summary>
        /// Creates a new generic Spawner.
        /// </summary>
        /// <param name="prefab">The prefab to use when Instantiating a new ISpawnable.</param>
        /// <param name="parent">The parent object to use for positioning newly spawned objects.</param>
        /// <param name="worldSpace">If true then the spawned object will be added to world space. Defaults to false.</param>
        public Spawner(GameObject prefab, Transform parent, int preloadCount = 0, bool worldSpace = false)
        {
            _prefab = prefab;
            _parent = parent;
            _worldSpace = worldSpace;

            if (preloadCount > 0)
            {
                Debug.Log(preloadCount);
                for (int i = 0; i < preloadCount; i++)
                {
                    Recycle(Instantiate().GameObject);
                }
            }
        }

        /// <summary>
        /// Spawns a new item of T at the position of the parent object.
        /// </summary>
        public void Spawn()
        {
            Spawn(null);
        }

        /// <summary>
        /// Spawns a new item of T at the position of the parent object.
        /// </summary>
        /// <param name="callback">A callback that receives the item once it has spawned.</param>
        public void Spawn(Action<T> callback)
        {
            T item;

            if (Count > 0)
            {
                item = Pop();
            }
            else
            {
                item = Instantiate();
            }

            item.GameObject.SetActive(true);
            item.GameObject.transform.position = _parent.position;
            callback?.Invoke(item);
        }

        T Instantiate()
        {
            T item;

            if (_worldSpace)
            {
                item = UnityEngine.Object.Instantiate(_prefab, _parent.transform.position, Quaternion.identity).GetComponent<T>();
            }
            else
            {
                item = UnityEngine.Object.Instantiate(_prefab, _parent).GetComponent<T>();
            }

            item.Despawn = (item) =>
            {
                Recycle(item);
            };

            return item;
        }

        void Recycle(GameObject item)
        {
            item.SetActive(false);
            Push(item.GetComponent<T>());
        }
    }
}
