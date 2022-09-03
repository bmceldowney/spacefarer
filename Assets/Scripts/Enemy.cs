using System;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour, ISpawnable
{
    [SerializeField]
    float _speed = 3f;
    [SerializeField]
    GameObject _enemyBody;
    [SerializeField]
    GameObject _explosionParticles;

    public GameObject GameObject { get { return gameObject; } }

    public Action<GameObject> Despawn { get; set; }

    public Action DoDamage { get; set; }

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
            DoDamage?.Invoke();
            Despawn(gameObject);
        }
    }

    async void OnTriggerEnter(Collider other)
    {
        await Explode();
        var slug = other.GetComponent<Slug>();
        slug?.Despawn(slug.gameObject);
    }

    async Task Explode()
    {
        _enemyBody.SetActive(false);
        _explosionParticles.SetActive(true);
        await Task.Delay(7500);
        _enemyBody.SetActive(true);
        _explosionParticles.SetActive(false);
        Despawn(gameObject);
    }
}
