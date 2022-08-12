using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabRespawn : MonoBehaviour
{
    public Crab crab;

    public void CrabSpawn()
    {
        Instantiate(crab);
        crab.transform.position = this.transform.position;
    }
    private void OnEnable()
    {
        //event from the crab baby 
        GameEvents.CrabSpawn += CrabSpawn;
    }
    private void OnDisable()
    {
        // event from the crab baby
        GameEvents.CrabSpawn -= CrabSpawn;
    }

}
