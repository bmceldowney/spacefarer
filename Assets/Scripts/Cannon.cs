using UnityEngine;
using Utils;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    GameObject _slugPrefab;
    [SerializeField]
    float _fireDelay = 0.3f;
    [SerializeField]
    bool _continuousFire = false;
    [SerializeField]
    float _yOffset = 0.3f;
    float _elapsedTime;
    Spawner<Slug> _slugPool;


    // Start is called before the first frame update
    void Start()
    {
        _elapsedTime = _fireDelay;
        _slugPool = new Spawner<Slug>(_slugPrefab, transform, 10, true);
    }

    // Update is called once per frame
    void Update()
    {
        float fire = Input.GetAxisRaw("Fire1");
        _elapsedTime += Time.deltaTime;

        if (fire > 0 || _continuousFire)
        {
            if (_elapsedTime >= _fireDelay)
            {
                _slugPool.Spawn(slug => slug.transform.localPosition += Vector3.up * _yOffset);
                _elapsedTime = 0;
            }
        }
    }
}
