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
        pauseButton.GetComponent<RectTransform>().localPosition = new Vector3(-width/2+40,height/2-20,10);
        ScoreText.GetComponent<RectTransform>().localPosition = new Vector3(-width/2+90,height/2-50,10);
        HP.GetComponent<RectTransform>().localPosition = new Vector3(-width/2+90,height/2-80,10);

        soundButton.GetComponent<RectTransform>().localPosition = new Vector3(width/2-20,height/2-20,10);
        cameraButton.GetComponent<RectTransform>().localPosition = new Vector3(width/2-40,height/2-50,10);
        flipButton.GetComponent<RectTransform>().localPosition = new Vector3(width/2-40,height/2-80,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
