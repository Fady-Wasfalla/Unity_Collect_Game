using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip GainCoin;
    public AudioClip MissCoin;
    public AudioClip GainLife;

    public AudioClip HitObstacle;

    public Button FlipButton;

    
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().playOnAwake=false;    
    }

    public void HitCoin(){
        if(Score.enableAudio){
        gameObject.GetComponent<AudioSource>().clip=GainCoin;
        gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void HitWrong(){
        if(Score.enableAudio){
        gameObject.GetComponent<AudioSource>().clip=MissCoin;
        gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void HitLife(){
        if(Score.enableAudio){
        gameObject.GetComponent<AudioSource>().clip=GainLife;
        gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void HitGameObstacle(){
        if(Score.enableAudio){
        gameObject.GetComponent<AudioSource>().clip=HitObstacle;
        gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
