using System;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour, ISpawnable
{
    [SerializeField]
    float _speed = 3f;

    public GameObject GameObject { get { return gameObject; } }

    public Action<GameObject> Despawn { get; set; }

    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        transform.Translate(0f, -Time.deltaTime * _speed, 0f);

        Vector3 viewportPoint = _camera.WorldToViewportPoint(transform.position);

        if (viewportPoint.y < 0)
        {
            Despawn(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Despawn(gameObject);
        var slug = other.GetComponent<Slug>();
        slug?.Despawn(slug.gameObject);
    }
}
