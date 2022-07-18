using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject music;
    public GameObject pauseMenuUI;
    public Image GameOverImage;
    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }
    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }
    private void GameOver()
    {
        GameOverImage.enabled = true;
    }
    //Different UI functions, all are accessed through OnClicks
    public void LoadSharkLevel()
    {
        SceneManager.LoadScene("Shark Bait");
        Time.timeScale = 1f;
    }
    public void LoadFishLevel()
    {
        SceneManager.LoadScene("Fish Ninja");
        Time.timeScale = 1f;
    }
    public void LoadShimpLevel()
    {
        SceneManager.LoadScene("Shrimp Jump");
        Time.timeScale = 1f;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        Destroy(GameObject.Find("Music"));
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameEvents.Pause?.Invoke();
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameEvents.Resume?.Invoke();
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        // restarts game w/ the reset button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
