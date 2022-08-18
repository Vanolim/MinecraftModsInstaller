using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class OpenFile : MonoBehaviour {
    private string downloadURL = "https://media1.tenor.com/images/92cbbf4aacb333461ec36fd39cfda856/tenor.gif?itemid=5275848";
    private string _fileName;

    public void Open(string fileName)
    {
        _fileName = fileName;
        StartCoroutine(BeginDownloadingContent());
        
        
        LoadContent(Application.persistentDataPath + _fileName);
    }
    IEnumerator BeginDownloadingContent() {
        string url = downloadURL;
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) {
                print(www.error);
            } else {

                string fileName = _fileName;
                string path = Path.Combine(Application.persistentDataPath, fileName); 
                File.WriteAllBytes(path, www.downloadHandler.data);
                LoadContent(path);
            }
        }
    }

    public void LoadContent(string path) {
        AndroidContentOpenerWrapper.OpenContent(path); 
    }
}
