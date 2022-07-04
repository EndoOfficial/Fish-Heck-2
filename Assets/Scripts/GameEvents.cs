using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void  OnSwipeStartDelegate(Vector2 startPosition, int touchCount);
    public static OnSwipeStartDelegate OnSwipeStart;
    
    public delegate void OnSwipeMoveDelegate(Vector2 movePosition, Vector2 moveDirection, float moveSpeed, int touchCount);
    public static OnSwipeMoveDelegate OnSwipeMove;
    
    public delegate void OnSwipeEndDelegate(Vector2 endPosition, Vector2 movePosition, float moveSpeed, int touchCount);
    public static OnSwipeEndDelegate OnSwipeEnd;
    
    public delegate void CoinScoreDelegate(); //Player touches coin
    public static CoinScoreDelegate CoinScore;
    
    public delegate void CoinEatDelegate(); //When shark eats the coin
    public static CoinEatDelegate CoinEat;
    
    public delegate void platformTiltTriggerDelegate(); //score has reached threshold to tilt the platform
    public static platformTiltTriggerDelegate platformTiltTrigger;
    
    public delegate void  FishScoreDelegate(int setScore); //add score when cut fish
    public static FishScoreDelegate FishScore;
    
    public delegate void TiltTriggerDelegate(); //platform tilting
    public static TiltTriggerDelegate TiltTrigger;
    
    public delegate void GameOverDelegate(); //Game Over
    public static GameOverDelegate GameOver;

    public delegate void DifficultyDelegate(); //increase fish dificulty
    public static DifficultyDelegate Difficulty;

    public delegate void PauseDelegate(); // on pause
    public static PauseDelegate Pause;

    public delegate void ResumeDelegate(); // on resume
    public static ResumeDelegate Resume;

    public delegate void LoseLifeDelegate(); // lose life
    public static LoseLifeDelegate LoseLife;
}
