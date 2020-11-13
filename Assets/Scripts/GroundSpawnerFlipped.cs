using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnerFlipped : MonoBehaviour
{
    public GameObject groundFlipped;
    Vector3 nextSpawnFlipped;

    public void spawnFlipped()
    {
        GameObject xF =  Instantiate(groundFlipped,nextSpawnFlipped,Quaternion.identity);
        nextSpawnFlipped = xF.transform.GetChild(1).transform.position;
    }
    void Start()
    {
        for(int i=0 ; i<10 ; i++){
            spawnFlipped();
        }

    }
}
