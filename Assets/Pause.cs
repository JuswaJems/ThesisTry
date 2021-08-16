using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;

    public void PauseButton()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        //unityeditor.editorapplication.isplaying = false;
        Application.Quit();
    }
}
