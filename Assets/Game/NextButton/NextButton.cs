using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextButton : MonoBehaviour
{
    public event Action OnClick;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => OnClick?.Invoke());
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
