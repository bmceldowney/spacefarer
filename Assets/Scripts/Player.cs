using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed = 8;
    [SerializeField]
    GameObject _playerTarget;

    void Start()
    {
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Move towards the player target
        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _playerTarget.transform.position, step);
    }
}
