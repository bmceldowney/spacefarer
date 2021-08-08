using System;
using UnityEngine;
using Utils;

public class Slug : MonoBehaviour, ISpawnable
{
    [SerializeField]
    float _speed = 20f;

    public GameObject GameObject { get { return gameObject; } }

    public Action<GameObject> Despawn { get; set; }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, _speed * Time.deltaTime, 0f);

        if (transform.position.y > 6)
        {
            Despawn(gameObject);
        }
    }
}
