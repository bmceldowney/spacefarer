using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    float _speed = 8;
    Camera _camera;
    float _margin = 0.1f;
    Vector3 _viewportPoint;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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

    Vector3 ConstrainInputPoint(Vector3 inputPoint)
    {
        //TODO: work out how to constrain both keyboard and touch input
        // or don't, whatever
        return new Vector3();
    }

}
