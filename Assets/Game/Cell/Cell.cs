using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DragAndDropHandler), typeof(Image), typeof(RectTransform))]
[RequireComponent(typeof(Canvas))]
public class Cell : MonoBehaviour
{
    public IndexPosition IndexPosition { get; set; }

    public DragAndDropHandler DragAndDrop { get; private set; }

    public bool Interactable
    {
        get => _interactable;
        set => SetInteractable(value);
    }

    public Color Color => _image.color;
    public Vector2 Position => _rectTransform.anchoredPosition;

    [SerializeField] private bool _interactable;

    [Space]
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _error;
    [SerializeField] private AudioSource _pickSound;

    private RectTransform _rectTransform;
    private Canvas _canvas;
    private Image _image;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponent<Canvas>();
        _image = GetComponent<Image>();
        DragAndDrop = GetComponent<DragAndDropHandler>();
        DragAndDrop.OnDrag += () => SetLayer(CellLayer.Source);
        DragAndDrop.OnDrop += PlayPick;
    }

    public void SetSize(Vector2 size)
    {
        _rectTransform.sizeDelta = size;
    }

    [ContextMenu("TakeColor")]
    public void TakeColor(Sprite gradient)
    {
        var texture = gradient.texture;
        var parent = transform.parent.GetComponent<RectTransform>();
        var pixelPos = _rectTransform.anchoredPosition / parent.rect.size * new Vector2(texture.width, texture.height);
        _image.color = texture.GetPixel((int)pixelPos.x, (int)pixelPos.y);
    }

    public void GoTo(Vector2 position)
    {
        DragAndDrop.TargetPosition = position;
    }

    public void SetLayer(CellLayer layer)
    {
        _canvas.sortingOrder = (int)layer;
    }

    public void ToogleError(bool active)
    {
        _error.SetActive(active);
    }

    private void SetInteractable(bool value)
    {
        _interactable = value;
        GetComponent<GraphicRaycaster>().enabled = _interactable;
        _cross.SetActive(!_interactable);
    }

    private void PlayPick()
    {
        _pickSound.Play();
    }

    #if UNITY_EDITOR
    private void OnValidate()
    {
        SetInteractable(_interactable);
    }
    #endif
}
