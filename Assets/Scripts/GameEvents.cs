using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void OnSwipeStartDelegate(Vector2 startPosition, int touchCount);
    public static OnSwipeStartDelegate OnSwipeStart;

    public delegate void OnSwipeMoveDelegate(Vector2 movePosition, Vector2 moveDirection, float moveSpeed, int touchCount);
    public static OnSwipeMoveDelegate OnSwipeMove;

    public delegate void OnSwipeEndDelegate(Vector2 endPosition, Vector2 moveDirection, float moveSpeed, int touchCount);
    public static OnSwipeEndDelegate OnSwipeEnd;

    public delegate void OnSwipeCardinalDelegate(TouchInput.SwipeCardinal cardinal);
    public static OnSwipeCardinalDelegate OnSwipeCardinal;

    public delegate void FishScoreDelegate(int setScore);
    public static FishScoreDelegate FishScore; 

    public delegate void ScoreToMintDelegate(int playerScore);
    public static ScoreToMintDelegate ScoreToMint;//goes to the GameData script to mint the score to fishcoin

    public delegate void FishCoinMintedDelegate(int FishCoin);
    public static FishCoinMintedDelegate FishCoinMinted; //minted nft

    public delegate void SharkEatDelegate(int setScore);
    public static SharkEatDelegate SharkEat; //When shark eats the coin

    public delegate void JellyMoveDelegate(Collider obj);
    public static JellyMoveDelegate JellyMove;// when jellyfish are eaten by the whale

    public delegate void SmallJellyMoveDelegate(Collider obj);
    public static SmallJellyMoveDelegate SmallJellyMove;// when small jellyfish are eaten by the whale

    public static Action TutorialOff; // Turns off the tutorial splash screen
    public static Action platformTiltTrigger; //score has reached threshold to tilt the platform
    public static Action TiltTrigger; //platform tilting
    public static Action GameOver; //Game Over
    public static Action Difficulty; //increase fish dificulty
    public static Action Pause; // on pause
    public static Action Resume; // on resume
    public static Action LoseLife; // miss fish / hit poison
    public static Action Poison; // poison food on plates
    public static Action PlayerDeath;// shark bait player dies, part of two part event that converts score to fishcoin
    public static Action CutSound; // play sound
    public static Action Cut; // when fish is cut
    public static Action EelReset; //resets eel under lose life conditions
    public static Action CrabSpawn; //spawns a crab
    public static Action PelletCheck; //Pellet checking for resetting
}
