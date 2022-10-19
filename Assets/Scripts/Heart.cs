using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Heart : MonoBehaviour
{
    Image _image;
    [SerializeField]
    Sprite[] _sprites;

    int _currentSpriteIndex = 0;
    float _timeSinceChange = 0;
    float _timeUntilChange = 4;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    async void Update()
    {
        _timeSinceChange += Time.unscaledDeltaTime;
        if (_timeUntilChange < _timeSinceChange)
        {
            Debug.Log($"currentSpriteIndex {_currentSpriteIndex}");
            _currentSpriteIndex = _currentSpriteIndex == 0 ? 1 : 0;
            _image.sprite = _sprites[_currentSpriteIndex];
            _timeSinceChange -= _timeUntilChange;
        }
        // Debug.Log($"unscaled time {Time.unscaledDeltaTime}");
    }
}
