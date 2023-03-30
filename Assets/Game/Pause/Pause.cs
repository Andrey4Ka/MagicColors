using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _toggle;

    private const string ShowKey = "Show";

    public void ShowClickHandler()
    {
        _toggle = !_toggle;
        _animator.SetBool(ShowKey, _toggle);
    }
}
