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

    private void OnEnable()
    {
        GameEvents.CoinScore += CoinSpawn;
        GameEvents.CoinEat += CoinEaten;
        GameEvents.FishScore += FishScore;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= CoinSpawn;
        GameEvents.CoinEat -= CoinEaten;
        GameEvents.FishScore -= FishScore;
    }

    public void FishScore(int setScore)
    {
        _playerScore += setScore;
        this.score.text = _playerScore.ToString();
        isScore = setScore;
    }

    public void RestartGame()
    {
        // restarts game w/ the reset button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    //load diffent levels in the main menu
    public void LoadSharkLevel()
    {
        SceneManager.LoadScene("Shark Bait");
    }
    public void LoadFishLevel()
    {
        SceneManager.LoadScene("Fish Ninja");
    }

}
