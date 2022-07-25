using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text score;
    public Text life;
    public Text fishCoinUI;

    public Image loseScreen;
    public int playerScore;
    public EventTrigger.TriggerEvent CoinScore;
    public Coin coinPrefab;
    private int thresholdCount; // Gives a score threshold for the tilt to occur at 5 point intervals
    public EventTrigger.TriggerEvent TiltTrigger;
    public Transform Platform;
    public int _life;

    public GameData gameData;


    private void Start()
    {
        if(score != null)
        {
            score.text = playerScore.ToString();
        }
        if (life != null)
        {
            life.text = _life.ToString();
        }
        if(fishCoinUI != null)
        {
        fishCoinUI.text = gameData.FishCoin.ToString();
        }
    }
    private void Update()
    {
        if(fishCoinUI != null)
        { 
        fishCoinUI.text = gameData.FishCoin.ToString();
        }
        score.text = playerScore.ToString();
    }
    private void OnEnable()
    {
        GameEvents.FishScore += FishScore;
        GameEvents.LoseLife += LoseLife;
        GameEvents.PlayerDeath += OnDeathReset;
        GameEvents.FishCoinMinted += FishCoinToUI;
        GameEvents.GameOver += GameOver;
    }
    private void OnDisable()
    {
        GameEvents.FishScore -= FishScore;
        GameEvents.LoseLife -= LoseLife;
        GameEvents.PlayerDeath -= OnDeathReset;
        GameEvents.FishCoinMinted -= FishCoinToUI;
        GameEvents.GameOver -= GameOver;
    }
    
    public void FishScore(int setScore)
    {
        //secret points that will move the platform every 5 points then reset
        thresholdCount++;
        if (thresholdCount >= 5)
        {
            GameEvents.TiltTrigger?.Invoke();
            thresholdCount = 0;
        }
        //player score that player sees
        playerScore += setScore;
        score.text = playerScore.ToString();
        if(playerScore < 0)
        {
            playerScore = 0;
            score.text = playerScore.ToString();
        }
    }
    private void LoseLife()
    {
        // simple life counter
        _life = _life - 1;
        life.text = _life.ToString();

        //gameover when life runs out
        if (_life <= 0)
        {
            GameEvents.ScoreToMint?.Invoke(playerScore);
            GameEvents.GameOver?.Invoke();
        }
    }

    void FishCoinToUI(int fishCoin) //prints fishcoin variable to the Ui
    {
        fishCoinUI.text = fishCoin.ToString();
    }
    void OnDeathReset() //facilitates the conversion process
    {
        GameEvents.ScoreToMint?.Invoke(playerScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        GameEvents.ScoreToMint(playerScore);
    }

}
