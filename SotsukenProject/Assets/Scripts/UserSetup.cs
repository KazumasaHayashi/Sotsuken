using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSetup : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private InputField inputField;
	private Text text;

    public static string username;

	void Start () {
		inputField = inputField.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ES2の扱いは正しいが、うまくテキストがとれていない
	public void RegistName(Text nametext){
		username = nametext.ToString();
		Debug.Log(username);
		ES2.Save<string>(username, "username");
	}

	public void CheckName(Text nametext){
		username = ES2.Load<string>("username");
		Debug.Log(username);
		
	}
	// public void RegistName(Text nametext, ){

	// 	Debug.Log(nametext.text);
	// }
}
