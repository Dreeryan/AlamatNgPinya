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

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/_Persistent.unity");

        EditorApplication.isPlaying = true;
    }
}
#endif
