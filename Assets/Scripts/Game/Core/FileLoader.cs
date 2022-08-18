using System;
using System.IO;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine;

public class FileLoader
{
    public event Action OnLoad;
    
    public void Load(string url, string nameNewFile)
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef =
            storage.GetReferenceFromUrl(url);

        string localUrl = Path.Combine(Application.persistentDataPath, nameNewFile);
        
        storageRef.GetFileAsync(localUrl).ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
                OnLoad?.Invoke();
        });
    }
}
