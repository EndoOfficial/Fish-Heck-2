using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action<Vector2, int> OnSwipeStart; //startPosition, touchCount
    public static Action<Vector2, Vector2, float, int> OnSwipeMove; //movePosition, moveDirection, moveSpeed, touchCount
    public static Action<Vector2, Vector2, float, int> OnSwipeEnd; //endPosition, moveSpeed, touchCount
    public static Action CoinScore; //Player touches coin
    public static Action CoinEat; //When shark eats the coin
    public static Action platformTiltTrigger; //score has reached threshold to tilt the platform
    public static Action<int> FishScore; //add score when cut fish
    public static Action TiltTrigger; //platform tilting
    public static Action GameOver; //Game Over
    public static Action Difficulty; //increase fish dificulty
    public static Action Pause; // on pause
    public static Action Resume; // on resume
    public static Action LoseLife; // miss fish / hit poison
    public static Action PlayerDeath;// shark bait player dies, part of two part event that converts score to fishcoin
    public static Action<int> ScoreToMint;//goes to the GameData script to mint the score to fishcoin
    public static Action<int> FishCoinMinted; //minted nft
}
