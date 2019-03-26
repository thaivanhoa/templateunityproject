using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogUtils 
{
    private const int kMaxLogSize = 16382;
    private static Vector2 scrollViewVector = Vector2.zero;

    public static void DebugLog(string s)
    {
        Debug.Log(s);
        string logText = "";
        logText += s + "\n";

        while (logText.Length > kMaxLogSize)
        {
            int index = logText.IndexOf("\n");
            logText = logText.Substring(index + 1);
        }
        scrollViewVector.y = int.MaxValue;
    }
}
