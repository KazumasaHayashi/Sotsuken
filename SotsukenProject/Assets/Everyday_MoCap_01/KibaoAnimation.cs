using UnityEngine;
using System.Collections;

// CubeのAnimatorの制御
public class KibaoAnimation : MonoBehaviour {
    Animator animator;
	int num;
	

    // スタート時に呼ばれる
    void Start () {
        this.animator = GetComponent<Animator>();

        
    }

    // フレーム毎に呼ばれる
    public void ChangeMotion(){
		
		CreateRandom();

		if (num == 1) {
            animator.CrossFade("Sitting_Laughing_01", 0.3f);
        }
		if (num == 2) {
            animator.CrossFade("Sitting_Talking_01", 0.3f);
        }
        if (num == 3) {
            animator.CrossFade("Sitting_Tired_01", 0.3f);
        }
		if (num == 4) {
            animator.CrossFade("Sitting_Talking_02", 0.3f);
        }
        if (num == 5) {
            animator.CrossFade("Sitting_Tired_02", 0.3f);
        }
		if (num == 6) {
            animator.CrossFade("Sitting_Talking_03", 0.3f);
        }
        if (num == 7) {
            animator.CrossFade("Sitting_Upset_02", 0.3f);
        }
        Debug.Log("きばお");
        Debug.Log(num);

	}

	private void CreateRandom(){
		Random.InitState( System.DateTime.Now.Millisecond);
		num = Random.Range(0,14);
	}
}