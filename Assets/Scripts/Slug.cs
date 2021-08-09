using System;
using UnityEngine;
using Utils;

public class Slug : MonoBehaviour, ISpawnable
{
    [SerializeField]
    float _speed = 20f;

    public GameObject GameObject { get { return gameObject; } }

    public Action<GameObject> Despawn { get; set; }

    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, _speed * Time.deltaTime, 0f);

        Vector3 viewportLocation = _camera.WorldToViewportPoint(transform.position);
        if (viewportLocation.y > 1)
        {
            Despawn(gameObject);
        }
    }
}
