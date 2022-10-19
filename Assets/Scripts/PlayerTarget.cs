using UnityEngine;

enum ControlScheme {
    None,
    Mouse,
    Touch,
    Axis
}

public class PlayerTarget : MonoBehaviour
{
    float _speed = 8;
    Camera _camera;
    float _margin = 0.1f;
    Vector3 _viewportPoint;
    [SerializeField]
    TimeController _timeController;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var currentControlScheme = DetermineControlScheme();

        switch (currentControlScheme) {
            case ControlScheme.Mouse:
                MouseMove();
                break;
            case ControlScheme.Touch:
                TouchMove();
                break;
            case ControlScheme.Axis:
                AxisMove();
                break;
            case ControlScheme.None:
                _timeController.SlowTime();
                break;
        }
    }

    ControlScheme DetermineControlScheme()
    {
        if (Input.GetMouseButton(0)) {
            return ControlScheme.Mouse;
        }

        if (Input.touchCount > 0) {
            return ControlScheme.Touch;
        }

        float hAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (hAxis != 0 || yAxis != 0 || Input.GetAxisRaw("Jump") != 0)
        {
            return ControlScheme.Axis;
        }

        return ControlScheme.None;
    }
    
    void MouseMove()
    {
        _timeController.StandardTime();

        var mousePosition = Input.mousePosition;
        var mouseVector = new Vector3(mousePosition.x, mousePosition.y, _camera.nearClipPlane);
        var targetPosition = _camera.ScreenToWorldPoint(mouseVector);
        targetPosition.z =  0;
        // var targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPosition;
    }

    void TouchMove()
    {
        _timeController.StandardTime();

        Touch touch = Input.GetTouch(0);
        var touchVector = new Vector3(touch.position.x, touch.position.y, _camera.nearClipPlane);
        var targetPosition = _camera.ScreenToWorldPoint(touchVector);
        targetPosition.z = 0;
        transform.position = targetPosition;
    }

    void AxisMove()
    {
        _timeController.StandardTime();

        float hAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

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
