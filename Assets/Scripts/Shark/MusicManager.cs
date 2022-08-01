using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource OST1; //normal music
    public AudioSource OST2; //tense music

    private void Start()
    { //makes sure the normal music is playing 
        OST1.Play();
    }
    private void Update()
    { //starts the next track
        if (gameManager.playerScore > 5)
        {
            OST1.gameObject.SetActive(false);
            OST2.gameObject.SetActive(true);
        }
    }
}
