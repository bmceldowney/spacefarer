using UnityEngine;

public class Ship : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = -1;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float unitsPerSecond = 5f;

        Vector3 direction = new Vector3(horizontal, vertical) * unitsPerSecond;
        transform.Translate(direction);
    }
}
