using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{   
    public Button ResumeGame;
    public Button RestartGame;
    public Button MainMenuGame;

    public Button PauseButton;

	public Toggle soundButton;	

	public Text ScoreText;
	public Text HPText;

    AudioSource m_AudioSource;

    GameObject[] pauseObjects;
    GameObject[] inGame;
    
    // Start is called before the first frame update
 	void Start () {
		m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Stop();
        soundButton.isOn=Score.enableAudio;
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		inGame = GameObject.FindGameObjectsWithTag("InGame");
		hidePaused();
        ResumeGame.onClick.AddListener(hidePaused);
        RestartGame.onClick.AddListener(RestartTheGame);
		MainMenuGame.onClick.AddListener(MainMenuButton);
		PauseButton.onClick.AddListener(PauseFunc);
		soundButton.onValueChanged.AddListener(delegate {
            ToggleValueChanged(soundButton);
        });
	}

	void ToggleValueChanged(Toggle change)
    {
        Score.enableAudio=soundButton.isOn;
		if(Score.enableAudio && Time.timeScale == 0){
	        m_AudioSource.Play();
		}else{
	        m_AudioSource.Stop();
		}
    }

    // Update is called once per frame
	void Update () {
		//uses the p button to pause and unpause the game
		ScoreText.text= "Score : "+Score.score;
		HPText.text= "Health : "+Score.HP;
		if (Score.isAlive){
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				PauseFunc();
			}
		}

	}

	public void PauseFunc(){
			if(Time.timeScale == 1)
			{
					Time.timeScale = 0;
					showPaused();
			} else if (Time.timeScale == 0){
					Time.timeScale = 1;
					hidePaused();
			}
	}
    	//Reloads the Level
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}

	//controls the pausing of the scene
	public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
        if(Score.enableAudio){
			m_AudioSource.Play();
		}
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}

		foreach(GameObject g in inGame){
			g.SetActive(false);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		m_AudioSource.Stop();
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
		foreach(GameObject g in inGame){
			g.SetActive(true);
		}
        Time.timeScale = 1;
	}

	//loads inputted level
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}

    public void RestartTheGame(){
		Score.score = 0;
		Score.HP = 3;
		Score.isAlive=true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void MainMenuButton(){
		Score.score = 0;
		Score.HP = 3;
		Score.isAlive=true;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
