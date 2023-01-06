using UnityEngine;

public class HintController : MonoBehaviour
{
    [SerializeField] private Animator _gradientAnimator;
    [SerializeField] private HintButton _hintButton;

    private const string AnimatorShowKey = "Show";

    private void Awake()
    {
        _hintButton.OnDown += () => SetShow(true);
        _hintButton.OnUp += () => SetShow(false);
    }

    public void SetShow(bool value)
    {
        _gradientAnimator.SetBool(AnimatorShowKey, value);
    }
}
