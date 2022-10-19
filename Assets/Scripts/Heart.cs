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

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    async void Update()
    {
        await Task.Delay(5000);
        _image.sprite = _sprites[0];
    }
}
