using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public float speed ;

    public float horizMultiplier = 2;

    public Rigidbody rb;

    bool down = true;

    float horizInput;

    public Button flipButton;

    bool alive = true;

    public Material MaterialBlue;
    public Material MaterialRed;
    public Material MaterialGreen;

    private float nextActionTime = 0.0f;
    private float nextFasterTime = 0.0f;
    public float period = 50.0f;
    public float faster = 7.0f;
 
    AudioSource m_AudioSource;
    bool musicPlay = true;
    bool musicPlay1 = true;

    private void Start() {
        m_AudioSource = GetComponent<AudioSource>();
        GetComponent<MeshRenderer>().material=MaterialRed;
        flipButton.onClick.AddListener(Flip);
    }

    void Main()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void FixedUpdate() {
        if (!alive){
            return;
        }
        // Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        // Vector3 horizMove = transform.right * horizInput * speed * Time.fixedDeltaTime * horizMultiplier;
        // rb.MovePosition(rb.position+forwardMove+horizMove);

        transform.Translate(0,0, speed * Time.fixedDeltaTime);


    }
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.R)){
            playerChangeColor();
        }
        if (Input.GetKeyUp(KeyCode.E)){
            Score.HP+=1;
        }
        if (Input.GetKeyUp(KeyCode.Q)){
            Score.score+=10;
        }
        if(Time.timeScale == 0){
             m_AudioSource.Stop();
             musicPlay=true;
        }
        if(Time.timeScale == 1 && musicPlay){
            playerMusicOn();
        }
        
        horizInput = Input.GetAxis("Horizontal");
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            transform.Translate(10*horizInput*Time.fixedDeltaTime,0,0);
        }else{
            transform.Translate(Input.acceleration.x/10, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Flip();
        }
        if(transform.position.y<-5){
            Die();
        }
        if(transform.position.x<-5 || transform.position.x>5){
            Die();
        }
        
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            playerChangeColor();
        }

        if (Time.time > nextFasterTime ) {
            nextFasterTime += faster;
            speed=speed+2f;
        }
        if(!Score.enableAudio){
            m_AudioSource.Pause();
            musicPlay1=true;
        }
        if(Score.enableAudio && musicPlay1){
            playerMusicOn1();
        }
    }

    public void playerMusicOn(){
         if(Score.enableAudio){
            m_AudioSource.Play();
        }else{
             m_AudioSource.Stop();
        }
        musicPlay=false;
    }

    public void playerMusicOn1(){
         if(Score.enableAudio){
            m_AudioSource.Play();
        }else{
             m_AudioSource.Stop();
        }
        musicPlay1=false;
    }
    
    public void playerChangeColor(){
        if(GetComponent<MeshRenderer>().material.name.Contains(MaterialRed.name)){
                    GetComponent<MeshRenderer>().material=MaterialBlue;
        }else{
            if(GetComponent<MeshRenderer>().material.name.Contains(MaterialBlue.name)){
                GetComponent<MeshRenderer>().material=MaterialGreen;
            }else{
                GetComponent<MeshRenderer>().material=MaterialRed;
            }
        }
    }
    public void Flip(){
        if(down){
                transform.Translate(0,4,0);
                down = false;   
        }else{
            transform.Translate(0,-4,0);
            down=true;
        }
    }

    public void Die(){
        alive=false;
        Score.isAlive=false;
        Destroy(gameObject);
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
    }
}
