using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public Button StartGame;
    
    public Button QuitGame;

    public Dropdown dropButton;

	public Toggle soundButton;	

    AudioSource m_AudioSource;


    GameObject[] htw;
    GameObject[] snd;
    GameObject[] crd;
    

    // Start is called before the first frame update
    void Start()
    {   
		m_AudioSource = GetComponent<AudioSource>();
		htw = GameObject.FindGameObjectsWithTag("HowToPlay");
		snd = GameObject.FindGameObjectsWithTag("SoundToggle");
		crd = GameObject.FindGameObjectsWithTag("Credits");
        soundButton.isOn=Score.enableAudio;
        if(Score.enableAudio){
            m_AudioSource.Play();
        }else{
             m_AudioSource.Stop();
        }
        showHowToPlay();
        StartGame.onClick.AddListener(startTheGame);
        QuitGame.onClick.AddListener(quitGameNow);
        dropButton.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropButton);
        });
        soundButton.onValueChanged.AddListener(delegate {
            ToggleValueChanged(soundButton);
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleValueChanged(Toggle change)
    {
        Score.enableAudio=soundButton.isOn;
        if(Score.enableAudio){
            m_AudioSource.Play();
        }else{
            m_AudioSource.Stop();
        }
    }

    public void startTheGame(){
		Score.score = 0;
		Score.HP = 3;
		Score.isAlive=true;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void DropdownValueChanged(Dropdown change)
    {
        if(change.value==0){
            showHowToPlay();
        }
        if(change.value==1){
            showSounds();
        }
        if(change.value==2){
            showCredits();
        }
    }

    public void showHowToPlay(){
		foreach(GameObject g in htw){
			g.SetActive(true);
		}
        foreach(GameObject g in snd){
			g.SetActive(false);
		}
        foreach(GameObject g in crd){
			g.SetActive(false);
		}
	}

    public void showSounds(){
		foreach(GameObject g in htw){
			g.SetActive(false);
		}
        foreach(GameObject g in snd){
			g.SetActive(true);
		}
        foreach(GameObject g in crd){
			g.SetActive(false);
		}
	}

    public void showCredits(){
		foreach(GameObject g in htw){
			g.SetActive(false);
		}
        foreach(GameObject g in snd){
			g.SetActive(false);
		}
        foreach(GameObject g in crd){
			g.SetActive(true);
		}
	}

    public void quitGameNow(){
         Application.Quit();
    }
}
