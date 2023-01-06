using System;
using UnityEngine;

public class YandexBridge : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    public static extern void ShowAd();
#endif

    public event Action OnAdClosed;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static YandexBridge Create()
    {
        return new GameObject("JsBridge").AddComponent<YandexBridge>();
    }

    public void AdClosed()
    {
        OnAdClosed?.Invoke();
    }
}
