using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button RestartGame;
    public Button MainMenuGame;

	public Text ScoreText;

    AudioSource t_AudioSource;

    bool audioPlayed = false;

    GameObject[] gameOverObjects;
    GameObject[] inGame;

    // Start is called before the first frame update
    void Start()
    {   
        t_AudioSource = GetComponent<AudioSource>();
        t_AudioSource.Stop();
		Time.timeScale = 1;
        gameOverObjects = GameObject.FindGameObjectsWithTag("GameOverTag");
		inGame = GameObject.FindGameObjectsWithTag("InGame");
        hideGameOver();
        RestartGame.onClick.AddListener(RestartTheGame);
		MainMenuGame.onClick.AddListener(MainMenuButton);
    }

    // Update is called once per frame
    void Update()
    {
		ScoreText.text= "Your Score is : "+Score.score;
        if(Score.isAlive==false){
            Time.timeScale = 0;
            if(!audioPlayed){
                showGameOver();
            }
        }
        if(!Score.enableAudio){
		    t_AudioSource.Stop();
        }
    }

    public void hideGameOver(){
		foreach(GameObject g in gameOverObjects){
			g.SetActive(false);
		}
        foreach(GameObject g in inGame){
			g.SetActive(true);
		}
        Time.timeScale = 1;
	}

    public void showGameOver(){
        if(Score.enableAudio){
		t_AudioSource.Play();
        }
		foreach(GameObject g in gameOverObjects){
			g.SetActive(true);
		}
        foreach(GameObject g in inGame){
			g.SetActive(false);
		}
        audioPlayed=true;
	}

    public void RestartTheGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Score.score = 0;
		Score.HP = 3;
		Score.isAlive=true;
    }

    public void MainMenuButton(){
		Score.score = 0;
		Score.HP = 3;
		Score.isAlive=true;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
