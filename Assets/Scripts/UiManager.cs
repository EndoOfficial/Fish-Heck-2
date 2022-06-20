using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
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
        GameOverImage.enabled = !GameOverImage.enabled;
    }
}
