using UnityEngine;
using UnityEngine.UI;

public class BgColor : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private float _saturation;
    [SerializeField] private float _speed;

    private float _hue;

    private const float Value = 1;

    private void Start()
    {
        _hue = Random.value;
        SetColor();
    }

    private void FixedUpdate()
    {
        _hue += Time.deltaTime * _speed;
        if (_hue > 1)
        {
            _hue = 0;
        }

        SetColor();
    }

    private void SetColor()
    {
        _bg.color = Color.HSVToRGB(_hue, _saturation, Value);
    }
}
