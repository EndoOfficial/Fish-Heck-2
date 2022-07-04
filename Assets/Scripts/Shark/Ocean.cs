using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ocean : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player");
        {
            GameEvents.PlayerDeath.Invoke();//sends event for fishcoin
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
