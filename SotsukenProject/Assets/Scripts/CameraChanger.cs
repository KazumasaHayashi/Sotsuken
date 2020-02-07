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
    [SerializeField]
    private GameObject camera7;
	[SerializeField]
    private GameObject camera8;
	[SerializeField]
    private GameObject camera9;
	[SerializeField]
    private GameObject camera10;
	[SerializeField]
    private GameObject camera11;
	
	private int cameraNumber = 0;
	

    void Start () {
	
    }
	//単位時間ごとに実行される関数
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space) && cameraNumber < 11){
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
                case 7:
                    ToCamera7(); 
                    break;
                case 8:
                    ToCamera8();
                    break;
                case 9:
                    ToCamera9();
                    break;
                case 10:
                    ToCamera10();
                    break;
                case 11:
                    ToCamera11();
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
                case 7:
                    ToCamera7(); 
                    break;
                case 8:
                    ToCamera8();
                    break;
                case 9:
                    ToCamera9();
                    break;
                case 10:
                    ToCamera10();
                    break;
                case 11:
                    ToCamera11();
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
        camera7.SetActive(false);
	}

    private void ToCamera7(){
		camera6.SetActive(false);
		camera7.SetActive(true);
        camera8.SetActive(false);
	}

    private void ToCamera8(){
		camera7.SetActive(false);
		camera8.SetActive(true);
        camera9.SetActive(false);
	}

    private void ToCamera9(){
		camera8.SetActive(false);
		camera9.SetActive(true);
        camera10.SetActive(false);
	}

    private void ToCamera10(){
		camera9.SetActive(false);
		camera10.SetActive(true);
        camera11.SetActive(false);
	}

    private void ToCamera11(){
		camera10.SetActive(false);
		camera11.SetActive(true);
        // camera12.SetActive(false);
	}

    // private void ToCamera12(){
	// 	camera11.SetActive(false);
	// 	camera12.SetActive(true);
    //     camera13.SetActive(false);
	// }


}