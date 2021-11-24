using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCamera : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    int _speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step =  _speed * Time.deltaTime;
        var x = Mathf.Clamp(player.transform.position.x, -3, 3);
        Vector3 target = new Vector3(x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
