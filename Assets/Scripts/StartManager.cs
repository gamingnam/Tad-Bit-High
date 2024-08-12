using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quitButton;

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void Settings()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
