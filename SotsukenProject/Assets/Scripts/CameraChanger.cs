using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraChanger : MonoBehaviour {
 
 	[SerializeField]
    private GameObject camera0;
	[SerializeField]
    private GameObject camera1;
	[SerializeField]
    private GameObject camera2;
	[SerializeField]
    private GameObject camera3;

	[SerializeField]
    private GameObject camera4;
	[SerializeField]
    private GameObject camera5;
	[SerializeField]
    private GameObject camera6;

	private int cameraNumber = 0;
	

		
 
    //呼び出し時に実行される関数
    void Start () {
        //メインカメラとサブカメラをそれぞれ取得
        // mainCamera = GameObject.Find("MainCamera");
        // subCamera = GameObject.Find("SubCamera");
 
        //サブカメラを非アクティブにする
        // subCamera.SetActive(false); 

	
    }
	//単位時間ごとに実行される関数
	void Update () {
		//スペースキーが押されている間、サブカメラをアクティブにする
        // if(Input.GetKey("space")){
        //     //サブカメラをアクティブに設定
        //     mainCamera.SetActive(false);
        //     subCamera.SetActive(true);
        // }
        // else{
        //     //メインカメラをアクティブに設定
        //     subCamera.SetActive(false);
        //     mainCamera.SetActive(true);
        // }

		if(Input.GetKeyDown(KeyCode.Space) && cameraNumber < 6){
			cameraNumber++;
            
            switch(cameraNumber){
                case 0:
                    ToCamera0(); 
                    break;
                case 1:
                    ToCamera1();
                    break;
                case 2:
                    ToCamera2();
                    break;
                case 3:
                    ToCamera3();
                    break;
                case 4:
                    ToCamera4();
                    break;
                case 5:
                    ToCamera5();
                    break;
                case 6:
                    ToCamera6();
                    break;
                
            }
		}
        
        if(Input.GetKeyDown(KeyCode.Backspace) && cameraNumber > 0){
			cameraNumber--;
            
            switch(cameraNumber){
                case 0:
                    ToCamera0(); 
                    break;
                case 1:
                    ToCamera1();
                    break;
                case 2:
                    ToCamera2();
                    break;
                case 3:
                    ToCamera3();
                    break;
                case 4:
                    ToCamera4();
                    break;
                case 5:
                    ToCamera5();
                    break;
                case 6:
                    ToCamera6();
                    break;
                
            }
		}
        

	}

	private void ToCamera0(){
		camera0.SetActive(true);
		camera1.SetActive(false);
	}

    private void ToCamera1(){
		camera0.SetActive(false);
		camera1.SetActive(true);
        camera2.SetActive(false);
	}

    private void ToCamera2(){
		camera1.SetActive(false);
		camera2.SetActive(true);
        camera3.SetActive(false);
	}

    private void ToCamera3(){
		camera2.SetActive(false);
		camera3.SetActive(true);
        camera4.SetActive(false);
	}

    private void ToCamera4(){
		camera3.SetActive(false);
		camera4.SetActive(true);
        camera5.SetActive(false);
	}

    private void ToCamera5(){
		camera4.SetActive(false);
		camera5.SetActive(true);
        camera6.SetActive(false);
	}

    private void ToCamera6(){
		camera5.SetActive(false);
		camera6.SetActive(true);
        // camera7.SetActive(false);
	}

    // private void ToCamera7(){
	// 	camera6.SetActive(false);
	// 	camera7.SetActive(true);
    //     camera8.SetActive(false);
	// }


}