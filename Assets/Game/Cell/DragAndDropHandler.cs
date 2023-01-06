using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action OnDrag;
    public event Action OnBeginDrag;
    public event Action OnDrop;

    public Vector2 TargetPosition { get; set; }

    [SerializeField] private float _smoothTime = 0.05f;

    private Vector3 _velocity;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        TargetPosition = transform.position;
    }

    private void Update()
    {
        if (TargetPosition == (Vector2)transform.position)
        {
            return;
        }

        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref _velocity, _smoothTime);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        TargetPosition = (Vector2)_camera.ScreenToWorldPoint(eventData.position);
        OnDrag?.Invoke();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        OnDrop?.Invoke();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDrag?.Invoke();
    }
}
