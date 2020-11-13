using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinNormal : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name!="Player"){
            return;
        }
        GameObject[] Sounds = GameObject.FindGameObjectsWithTag("Sound");
        GameObject playSound = Sounds[0];
        if(gameObject.GetComponent<MeshRenderer>().material.name.Contains("Yellow")){
            if(Score.HP<3){
                playSound.GetComponent<SoundEffects>().HitLife();
                Score.HP+=1;
            }
            Destroy(gameObject);
            return;
        }
        if(other.gameObject.GetComponent<MeshRenderer>().material.name.Contains(gameObject.GetComponent<MeshRenderer>().material.name)){
            Score.score+=10;
            playSound.GetComponent<SoundEffects>().HitCoin();
        }else{
            Score.score-=5;
            playSound.GetComponent<SoundEffects>().HitWrong();
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed*Time.deltaTime);
    }
}
