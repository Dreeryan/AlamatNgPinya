using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DebugLoadSpecificScene : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject panel;
    [SerializeField] private KeyCode toggleKey = KeyCode.F1;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey)) panel.SetActive(!panel.activeSelf);
    }

    public void LoadScene()
    {
        SceneLoader loader = FindObjectOfType<SceneLoader>();
        if (loader == null) return;

        string sceneToLoad = inputField.text;

        // https://gist.github.com/yagero/2cd50a12fcc928a6446539119741a343
        for (int x = 0; x < SceneManager.sceneCountInBuildSettings; x++)
        {
            var scenePath = SceneUtility.GetScenePathByBuildIndex(x);
            var lastSlash = scenePath.LastIndexOf("/");
            var sceneName = scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1);

            if (string.Compare(sceneToLoad, sceneName, true) == 0)
            {
                print("Scene exists");
                Time.timeScale = 1.0f;
                SceneLoader.ChangeScene(sceneToLoad);
                return;
            }
        }
        print("No scene exists");
    }
}
