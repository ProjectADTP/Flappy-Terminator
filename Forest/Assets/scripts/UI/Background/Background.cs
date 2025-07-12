using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private float _offsetX;

    private Rect _Rect; 

    private void Awake()
    {
        if (_image == null) return;

        _Rect = _image.uvRect;
    }

    private void Update()
    {
        if (_image == null) return;

        float newX = Mathf.Repeat(_Rect.position.x + _offsetX, 1f);

        _Rect.position = new Vector2(newX, _Rect.position.y);
        _image.uvRect = _Rect;
    }
}
