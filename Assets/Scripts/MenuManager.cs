using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button startButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button restartButton;

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject loseMenu;

    public static bool isPaused;

    [SerializeField] float masterVolume;
    [SerializeField] float musicVolume;
    [SerializeField] float SFXVolume;


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
    public void Settings()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Lose()
    {
        loseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);

    }
}
