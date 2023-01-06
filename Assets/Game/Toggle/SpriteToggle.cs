using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SpriteToggle : MonoBehaviour
{
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(ToggleSprite);
    }

    private void ToggleSprite(bool value)
    {
        ((Image)_toggle.targetGraphic).sprite = value ? _on : _off;
    }
}
