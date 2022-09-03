using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    float _pausedTimescale = 0.2f;
    [SerializeField]
    float _defaultTimescale = 1f;

    public void SlowTime()
    {
        if (Time.timeScale != _pausedTimescale)
        {
            Time.timeScale = _pausedTimescale;
        }
    }

    public void StandardTime()
    {
        if (Time.timeScale != _defaultTimescale)
        {
            Time.timeScale = _defaultTimescale;
        }
    }
}
