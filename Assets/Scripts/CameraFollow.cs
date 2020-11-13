using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{   
    public Transform player;
    public Button cameraButton;
    public Button flipButton;
    Vector3 offset;
    bool cameraModeThird = true;
    int third_y_camera = 3;
    // Start is called before the first frame update
    void Start()
    {   
        offset = transform.position - player.position;
        cameraButton.onClick.AddListener(ChangeCameraMood);
        flipButton.onClick.AddListener(Flip);
    }

    // Update is called once per frame
    void Update()
    {   
        if(player){
        if (Input.GetKeyUp(KeyCode.C)){
            ChangeCameraMood();
        }

        if (cameraModeThird){
            if (Input.GetKeyUp(KeyCode.Space)){
                Flip();
            }
            Vector3 targPos = player.position + offset;
            targPos.x=0;
            targPos.y=third_y_camera;
            transform.position = targPos;
        }
        else{
            Vector3 targPos = player.position + offset;
            targPos.x=-10;
            targPos.y=third_y_camera;
            targPos.z=targPos.z+10;
            transform.position = targPos;
        }
        
        }
    }

    public void ChangeCameraMood(){
       if(cameraModeThird){
                transform.Rotate(0,90,0);
            }else{
                transform.Rotate(0,-90,0);
            }
        cameraModeThird=!cameraModeThird;
    }

    public void Flip(){
        if(third_y_camera==2){
                third_y_camera=3;
        }else{
                third_y_camera=2;
        }
    }
}
