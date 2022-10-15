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
    Vector3 _target;
    Camera _camera;

    public void Initialize (Vector3 spawnLocation)
    {
        _camera = Camera.main;
        gameObject.transform.Translate(spawnLocation, Space.World);
        _target = _camera.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0f, 1f), -0.1f, -_camera.transform.position.z));
    }

    void Update()
    {
        Vector3 direction = _target - transform.position;
        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _target, step);

        if (Vector3.Distance(transform.position, _target) < 0.1f)
        {
            Unspawn();
        }
    }

    async void OnTriggerEnter(Collider other)
    {
        var slug = other.GetComponent<Slug>();
        slug?.Despawn(slug.gameObject);
        await Explode();
    }

    async Task Explode()
    {
        _enemyBody.SetActive(false);
        _explosionParticles.SetActive(true);
        await Task.Delay(7500);
        _enemyBody?.SetActive(true);
        _explosionParticles?.SetActive(false);
        Unspawn();
    }

    void Unspawn()
    {
        Despawn(gameObject);
    }

    void FixedUpdate()
    {
        // Debug.DrawLine(transform.position, _target, Color.red);
    }
}
