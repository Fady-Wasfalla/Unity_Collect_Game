using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalObstacle : MonoBehaviour
{
    PlayerMove player;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMove>(); 
    }

    private void OnCollisionEnter(Collision other) {
        GameObject[] Sounds = GameObject.FindGameObjectsWithTag("Sound");
        GameObject playSound = Sounds[0];
        if (other.gameObject.name == "Player" ){
            if(Score.HP==0){
                player.Die();
                return;
            }
            playSound.GetComponent<SoundEffects>().HitGameObstacle();
            Score.HP-=1;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
