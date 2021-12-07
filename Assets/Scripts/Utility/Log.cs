using UnityEngine;

public static class Log
{
    public static void Info(string text)
    {
#if UNITY_EDITOR
        Debug.Log(text);
#endif
    }

    public static void Warning(string text)
    {
#if UNITY_EDITOR
        Debug.LogWarning(text);
#endif
    }

    public static void Error(string text)
    {
#if UNITY_EDITOR
        Debug.LogError(text);
#endif
    }
}
