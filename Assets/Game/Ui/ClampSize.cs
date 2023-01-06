using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ClampSize : MonoBehaviour
{
    [SerializeField] private bool _clampWidth;
    [SerializeField] private float _maxWidth;

    [Space]
    [SerializeField] private bool _clampHeight;
    [SerializeField] private float _maxHeight;

    private void Start()
    {
        var rectTransform = GetComponent<RectTransform>();
        var rect = rectTransform.rect;
        if (_clampWidth)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Min(rect.width, _maxWidth));
        }

        if (_clampHeight)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Min(rect.height, _maxHeight));
        }
    }
}
