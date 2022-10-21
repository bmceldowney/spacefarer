using System;
using System.Threading.Tasks;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, ISpawnable
{
    [SerializeField]
    float _maxSpeed = 9f;
    [SerializeField]
    float _minSpeed = 5f;
    [SerializeField]
    float _currentSpeed;
    [SerializeField]
    float _rotationSpeed;
    [SerializeField]
    GameObject _enemyBody;
    [SerializeField]
    GameObject _explosionParticles;

    public GameObject GameObject { get { return gameObject; } }
    public Action<GameObject> Despawn { get; set; }
    public Action<int> Eliminated { get; set; }
    Vector3 _target;
    Camera _camera;
    Boolean _isExploding = false;
    Quaternion _currentRotation;

    public void Initialize (Vector3 spawnLocation)
    {
        _camera = Camera.main;
        _isExploding = false;
        gameObject.transform.Translate(spawnLocation, Space.World);
        _target = _camera.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0f, 1f), -0.1f, -_camera.transform.position.z));
        _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
        float rotationStep = _rotationSpeed * Time.deltaTime;
        _currentRotation = Random.rotation;
    }

    void Update()
    {
        Vector3 direction = _target - transform.position;
        float step = _currentSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _target, step);
        transform.rotation = transform.rotation * _currentRotation;

        if (Vector3.Distance(transform.position, _target) < 0.1f && !_isExploding)
        {
            Unspawn();
        }
    }

    async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var slug = other.GetComponent<Slug>();
            slug?.Despawn(slug.gameObject);
            if (slug != null)
            {
                Eliminated?.Invoke(10);
            }

            await Explode();
        }
    }

    async Task Explode()
    {
        _isExploding = true;
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
