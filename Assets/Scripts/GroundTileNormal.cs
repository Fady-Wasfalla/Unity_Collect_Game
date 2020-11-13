using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileNormal : MonoBehaviour
{
    GroundSpawnerNormal groundSpawn ; 

    private float nextActionTime = 0.0f;

    public float period = 13.0f;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawnerNormal>();
        normalSpObstacle();
        normalSpCoin();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawn.spawnNormal();
        Destroy(gameObject,2);
    }
    // Update is called once per frame
    void Update()
    {
        nextActionTime += period;
    }

    public GameObject Obstacle;

    void normalSpObstacle(){
         int obstInd = Random.Range(2,5);;
        Transform spawnPoint;

        if (Time.time > nextActionTime && obstInd==3 ) {
            // nextActionTime += period;
            int obstShape = Random.Range(1,4);
            spawnPoint = transform.GetChild(3);
            if (obstShape>1 ){
                if(obstShape==2){
                    Vector3 scl = new Vector3(6.6f,1f,1f);
                    Obstacle.transform.localScale=scl;
                    int left = Random.Range(0,2);
                    if (left==1){
                        spawnPoint.position=new Vector3(spawnPoint.position.x-1.65f,spawnPoint.position.y,spawnPoint.position.z);
                    }else{
                        spawnPoint.position=new Vector3(spawnPoint.position.x+1.65f,spawnPoint.position.y,spawnPoint.position.z);
                    }
                }
                if(obstShape==3){
                    Vector3 scl = new Vector3(10f,1f,1f);
                    Obstacle.transform.localScale=scl;
                    spawnPoint.position=new Vector3(spawnPoint.position.x,spawnPoint.position.y,spawnPoint.position.z);
                }  
            }
        }else{
                obstInd = Random.Range(2,5);
                spawnPoint = transform.GetChild(obstInd);
        }

        Instantiate(Obstacle,spawnPoint.position,Quaternion.identity,transform);
        Obstacle.transform.localScale=new Vector3(3.3f,1f,1f);
    }

    public GameObject Coin;
    public Material MaterialBlue;
    public Material MaterialRed;
    public Material MaterialGreen;
    public Material MaterialYellow;

    void normalSpCoin(){
        int co = 3;
        for(int i=0;i<co;i++){
           GameObject tem = Instantiate(Coin,transform);
           tem.transform.position = GetRandomPoint(GetComponent<Collider>());
           int chosenCol = Random.Range(1,5);
           switch (chosenCol)
           {
               case 1:
                tem.GetComponent<MeshRenderer>().material=MaterialBlue;
               break;

               case 2:
                tem.GetComponent<MeshRenderer>().material=MaterialRed;
               break;

               case 3:
                tem.GetComponent<MeshRenderer>().material=MaterialGreen;
               break;

               case 4:
                tem.GetComponent<MeshRenderer>().material=MaterialYellow;
               break;

           }
        }
    }

    Vector3 GetRandomPoint (Collider other){
        Vector3 point = new Vector3(
            Random.Range(GetComponent<Collider>().bounds.min.x,GetComponent<Collider>().bounds.max.x),
            Random.Range(GetComponent<Collider>().bounds.min.y,GetComponent<Collider>().bounds.max.y),
            Random.Range(GetComponent<Collider>().bounds.min.z,GetComponent<Collider>().bounds.max.z)
        );

        if (point != GetComponent<Collider>().ClosestPoint(point)){
            point = GetRandomPoint(GetComponent<Collider>());
        }

        point.y=1;
        return point;
    }
}
