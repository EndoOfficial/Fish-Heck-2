using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text score;
    public Image loseScreen;
    public int _playerScore;
    public EventTrigger.TriggerEvent CoinScore;
    public Transform[] CSpawnPointsLibrary;
    public Coin coinPrefab;
    private Coin currentCoin;
    private int thresholdCount; // Gives a score threshold for the tilt to occur at 5 point intervals
    public EventTrigger.TriggerEvent TiltTrigger;
    public Transform Platform;
    public int isScore;

    public GameObject pauseMenuUI;

    private void OnEnable()
    {
        GameEvents.CoinScore += CoinScoreUI;
        GameEvents.FishScore += FishScore;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= CoinScoreUI;
        GameEvents.FishScore -= FishScore;
    }

    public void FishScore(int setScore)
    {
        _playerScore += setScore;
        this.score.text = _playerScore.ToString();
        isScore = setScore;

        if (_playerScore >= 200 && _playerScore <= 202)
        {
            GameEvents.Difficulty?.Invoke();
        }
        else if (_playerScore >= 400 && _playerScore <= 402)
        {
            GameEvents.Difficulty?.Invoke();
        }
    }


    public void CoinScoreUI()
    {
        thresholdCount++;
        _playerScore++;
        this.score.text = _playerScore.ToString();
        Debug.Log("score" + _playerScore.ToString());
    }


    private void Update()
    {
        //secret points that will move the platform every 5 points then reset
        if (thresholdCount == 5)
        {
            GameEvents.TiltTrigger.Invoke();
            thresholdCount = 0;
            Debug.Log("tilt");
        }

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
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
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
