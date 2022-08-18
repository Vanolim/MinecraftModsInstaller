using UnityEngine;
using System.IO;

public class AndroidContentOpenerWrapper {
    private static AndroidJavaClass m_ajc = null;
    private static AndroidJavaClass AJC {
        get {
            if (m_ajc == null) {
                m_ajc = new AndroidJavaClass("com.cartoontexas.andyr.unityplugin.ContentOpener"); 
            }
            return m_ajc;
        }
    }

    private static AndroidJavaObject m_context = null;
    private static AndroidJavaObject Context {
        get {
            if (m_context == null) {
                using (AndroidJavaObject unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                    m_context = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
                }
            }
            return m_context;
        }
    }

    public static void OpenContent(string filePath) {
        if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath)) {
            AJC.CallStatic("OpenContent", Context, filePath); 
        } else {
            Debug.LogError("File does not exist at path or permission denied: " + filePath);
        }
    }
}
