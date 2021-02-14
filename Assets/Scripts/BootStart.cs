using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStart : MonoBehaviour
{
    private void Start()
    {
        //SceneLoader loader = FindObjectOfType<SceneLoader>();

        if (SceneLoader.Instance == null) return;

        SceneLoader.Instance.LoadScene("MainMenu");
    }

}
