using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed = 2;
    Camera _camera;
    float _margin = 0.1f;
    Vector3 _viewportPoint;
    Rect _cameraRect;
    Vector3 _screenPoint;

    void Start()
    {
        _camera = Camera.main;
        _cameraRect = _camera.pixelRect;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        //Debug.Log($"hAxis: {Input.GetAxisRaw("Horizontal")}");

        // constrain the player to the bounds of the camera
        float min = _margin;
        float max = 1 - _margin;
        _viewportPoint = _camera.WorldToViewportPoint(transform.position);
        _screenPoint = _camera.WorldToScreenPoint(transform.position);
        //Debug.Log($"world to screen point: {_screenPoint}");
        if (_viewportPoint.x <= min && hAxis < 0) hAxis = 0;
        if (_viewportPoint.y <= min && yAxis < 0) yAxis = 0;
        if (_viewportPoint.x >= max && hAxis > 0) hAxis = 0;
        if (_viewportPoint.y >= max && yAxis > 0) yAxis = 0;

        transform.Translate(new Vector3(hAxis, yAxis, 0) * _speed * Time.deltaTime);
    }
}
