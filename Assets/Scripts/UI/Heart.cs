using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField]
    Sprite[] _sprites;

    Image _image;
    int _currentSpriteIndex = 0;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetValue(bool full)
    {
        if (!gameObject.activeInHierarchy) return;
        _currentSpriteIndex = full ? 1 : 0;
        _image.sprite = _sprites[_currentSpriteIndex];
    }
}
