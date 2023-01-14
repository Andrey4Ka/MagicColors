#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

public static class YandexPrefs
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    public static extern void PrefsSetInt(string key, int value);
    [DllImport("__Internal")]
    public static extern int PrefsGetInt(string key, int defaultValue);
    [DllImport("__Internal")]
    public static extern void PrefsSetBool(string key, bool value);
    [DllImport("__Internal")]
    public static extern bool PrefsGetBool(string key, bool defaultValue);
#endif

    public static void SetInt(string key, int value)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PrefsSetInt(key, value);
#endif
    }

    public static int GetInt(string key, int defaultValue)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        return PrefsGetInt(key, defaultValue);
#endif
        return defaultValue;
    }

    public static void SetBool(string key, bool value)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PrefsSetBool(key, value);
#endif
    }

    public static bool GetBool(string key, bool defaultValue)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        return PrefsGetBool(key, defaultValue);
#endif
        return defaultValue;
    }
}
