using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPositions : MonoBehaviour
{

	public Text ScoreText;
    public Text HP;
    public Button pauseButton;

	public Toggle soundButton;	
    public Button cameraButton;
    public Button flipButton;



    // Start is called before the first frame update
    void Start()
    {
        int width = Screen.width;
        int height = Screen.height;

        pauseButton.GetComponent<RectTransform>().sizeDelta = new Vector2(width/10,height/20);
        ScoreText.GetComponent<RectTransform>().sizeDelta = new Vector2(width/8,height/15);
        HP.GetComponent<RectTransform>().sizeDelta = new Vector2(width/8,height/15);

        pauseButton.GetComponent<RectTransform>().localPosition = new Vector3(-width/2.5f,height/2.5f,10);
        ScoreText.GetComponent<RectTransform>().localPosition = new Vector3(-width/2.5f,height/3.0f,10);
        HP.GetComponent<RectTransform>().localPosition = new Vector3(-width/2.5f,height/3.5f,10);



        soundButton.GetComponent<RectTransform>().localPosition = new Vector3(width/2.5f,height/3.5f+100,10);
        cameraButton.GetComponent<RectTransform>().localPosition = new Vector3(width/2.5f,height/3.5f+50,10);
        flipButton.GetComponent<RectTransform>().localPosition = new Vector3(width/2.5f,height/3.5f,10);

        soundButton.GetComponent<RectTransform>().sizeDelta = new Vector2(width/10,height/20);
        cameraButton.GetComponent<RectTransform>().sizeDelta = new Vector2(width/10,height/20);
        flipButton.GetComponent<RectTransform>().sizeDelta = new Vector2(width/10,height/20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
