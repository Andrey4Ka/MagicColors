using System;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif
using UnityEngine;

public class YandexBridge : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    public static extern void ShowAd();
#endif

    public event Action OnAdClosed;

    public static YandexBridge Create()
    {
        return new GameObject("YandexBridge").AddComponent<YandexBridge>();
    }

    public void SendShowAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowAd();
#else
        AdClosed();
#endif
    }

    public void AdClosed()
    {
        OnAdClosed?.Invoke();
    }
}
