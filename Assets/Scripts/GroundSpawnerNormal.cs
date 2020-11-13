using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnerNormal : MonoBehaviour
{
    public GameObject ground;
    Vector3 nextSpawn;

    public void spawnNormal()
    {
        GameObject x =  Instantiate(ground,nextSpawn,Quaternion.identity);
        nextSpawn = x.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0 ; i<10 ; i++){
            spawnNormal();
        }

    }
}
