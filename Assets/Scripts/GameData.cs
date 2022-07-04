using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameData")]
public class GameData : ScriptableObject
{
    private int FishCoin;
    public Text FishCoinUI;

    private void Awake()
    {
        FishCoinUI = FishCoinUI.GetComponent<Text>();
    }
    private void OnEnable()
    {
        GameEvents.ScoreToMint += MintCoin;
    }
    private void OnDisable()
    {
        GameEvents.ScoreToMint -= MintCoin;
    }
    void MintCoin(int _playerScore)
    {
        FishCoin += _playerScore;
       GameEvents.FishCoinMinted?.Invoke(FishCoin);
    }
}
