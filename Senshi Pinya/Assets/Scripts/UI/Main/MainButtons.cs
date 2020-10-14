using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainButtons : MonoBehaviour
{
    public void PauseBtn()
    {

    }

    public void ResumeBtn()
    {

    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
