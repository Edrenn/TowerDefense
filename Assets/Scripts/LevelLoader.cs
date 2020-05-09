using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadNextLevel(int currentSceneId)
    {
        Scene nextScene = SceneManager.GetSceneByName("Level" + currentSceneId+1);
        SceneManager.LoadScene(nextScene.name);
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }

    internal void ReloadGame()
    {
        SceneManager.LoadScene("SplashScreen");
    }

    public void LoadVictoryScreen()
    {
        SceneManager.LoadScene("VictoryScreen");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelSelection()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelectionScreen");
    }

    public void LoadOptionsScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("OptionScreen");
    }

    public void LoadUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeScreen");
    }

    public void LoadEndGameScene()
    {
        SceneManager.LoadScene("EndGameScreen");
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
