using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseFunction : MonoBehaviour
{
    public GameObject pauseBtn;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseBtn.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseBtn.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
