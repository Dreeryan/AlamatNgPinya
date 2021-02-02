using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStart : MonoBehaviour
{
    private void Start()
    {
        SceneLoader loader = FindObjectOfType<SceneLoader>();

        if (loader == null) return;

        loader.ChangeScene("MainMenu");
    }

}
