using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text score;
    public Text life;
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
    public int lifePoints;

    public GameObject pauseMenuUI;

    private void OnEnable()
    {
        GameEvents.CoinScore += CoinSpawn;
        GameEvents.CoinEat += CoinEaten;
        GameEvents.FishScore += FishScore;
        GameEvents.loseLife += loseLife;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= CoinSpawn;
        GameEvents.CoinEat -= CoinEaten;
        GameEvents.FishScore -= FishScore;
        GameEvents.loseLife -= loseLife;
    }
    private void Start()
    {
        this.life.text = lifePoints.ToString();
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
    // add score when sashimi hits a box
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


    public void CoinSpawn()
    {

        //Pick a random interger from the library then store that transform position
        int randomInt = Random.Range(0, CSpawnPointsLibrary.Length);
        Transform randomPoint = CSpawnPointsLibrary[randomInt];
        if (randomPoint.gameObject.activeSelf)
        {
            //Use that transform position to clone a prefab coin to 
            currentCoin = Instantiate(coinPrefab);
            currentCoin.transform.position = randomPoint.position;
            //Give the player a point
            thresholdCount++;
            _playerScore++;
            this.score.text = _playerScore.ToString();
            Debug.Log("score" + _playerScore.ToString());
        }
    }


    public void CoinEaten()
    {
        //Pick a random interger from the library then store that transform position
        int randomInt = Random.Range(0, CSpawnPointsLibrary.Length);
        Transform randomPoint = CSpawnPointsLibrary[randomInt];
        if (randomPoint.gameObject.activeSelf)
        {
            //Use that transform position to clone a prefab coin to 
            currentCoin = Instantiate(coinPrefab);
            currentCoin.transform.position = randomPoint.position;
        }
    }

    //lose life and gameover when life = 0
    private void loseLife()
    {
        lifePoints--;
        this.life.text = lifePoints.ToString();
        if (lifePoints == 0)
        {
            GameEvents.GameOver?.Invoke();
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
