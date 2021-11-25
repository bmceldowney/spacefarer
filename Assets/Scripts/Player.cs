using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed = 8;
    Camera _camera;
    float _margin = 0.1f;
    Vector3 _viewportPoint;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Move();
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var touchVector = new Vector3(touch.position.x, touch.position.y, _camera.nearClipPlane);
            var targetPosition = _camera.ScreenToWorldPoint(touchVector);
            targetPosition.z = 0;
            transform.position = targetPosition;
        }
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // constrain the player to the bounds of the camera viewport
        float min = _margin;
        float max = 1 - _margin;
        _viewportPoint = _camera.WorldToViewportPoint(transform.position);

        if (_viewportPoint.x <= min && hAxis < 0) hAxis = 0;
        if (_viewportPoint.y <= min && yAxis < 0) yAxis = 0;
        if (_viewportPoint.x >= max && hAxis > 0) hAxis = 0;
        if (_viewportPoint.y >= max && yAxis > 0) yAxis = 0;

        float multiplier = _speed * Time.deltaTime;
        transform.Translate(hAxis * multiplier, yAxis * multiplier, 0);
    }
}
