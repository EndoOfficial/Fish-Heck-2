using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameData")]
public class GameData : ScriptableObject
{
    public int FishCoin;

    private void OnEnable()
    {
        GameEvents.ScoreToMint += MintCoin;
    }
    private void OnDisable()
    {
        GameEvents.ScoreToMint -= MintCoin;
    }
    void MintCoin(int playerScore)
    {
       FishCoin += playerScore;
       GameEvents.FishCoinMinted?.Invoke(FishCoin);
    }
}
