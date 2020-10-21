using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
