using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    float _pausedTimescale = 0.2f;
    [SerializeField]
    float _defaultTimescale = 1f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            StandardTime();
        } else {
            SlowTime();
        }
    }

    public void SlowTime()
    {
        Time.timeScale = _pausedTimescale;
    }

    public void StandardTime()
    {
        Time.timeScale = _defaultTimescale;
    }
}
