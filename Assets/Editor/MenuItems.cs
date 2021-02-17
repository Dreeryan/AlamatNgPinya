using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuItems
{
    [MenuItem("Game/PLAY GAME")]
    public static void PlayGame()
    {
        if (EditorApplication.isPlaying) return;

        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/_Persistent.unity");

            EditorApplication.isPlaying = true;
        }
    }

    [MenuItem("Game/ DELETE ALL SAVES")]
    public static void DeleteSaves()
    {
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] files = di.GetFiles("*.sav");

        foreach (FileInfo file in files)
        {
            File.Delete(file.FullName);
        }

        Debug.LogError("Saves deleted!");
    }
}
#endif
