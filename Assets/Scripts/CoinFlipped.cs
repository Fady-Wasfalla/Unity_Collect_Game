using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipped : MonoBehaviour
{
    public float turnSpeed = 90f;
    public AudioClip GainCoin;
    public AudioClip MissCoin;
    public AudioClip GainLife;

    

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().playOnAwake=false;
    }

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
            Score.score-=5;
            playSound.GetComponent<SoundEffects>().HitWrong();
        }else{
            Score.score+=10;
            playSound.GetComponent<SoundEffects>().HitCoin();
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed*Time.deltaTime);
    }
}

