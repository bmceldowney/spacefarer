using UnityEngine;
using Utils;

public class Cannon : MonoBehaviour, IFireable
{
    [SerializeField]
    GameObject _slugPrefab;
    [SerializeField]
    float _fireDelay = 0.3f;
    [SerializeField]
    float _yOffset = 0.3f;
    float _elapsedTime;
    Spawner<Slug> _slugPool;

    public bool AutoFire { get; private set; }

    public void Fire()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _fireDelay)
        {
            _slugPool.Spawn(slug => slug.transform.localPosition += Vector3.up * _yOffset);
            _elapsedTime = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _elapsedTime = _fireDelay;
        _slugPool = new Spawner<Slug>(_slugPrefab, transform, 10, true);
    }
}
