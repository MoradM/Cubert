using UnityEngine;
using System.Collections;

public class finalScene : MonoBehaviour {
	
	public Texture finalSceneImage;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			Application.LoadLevel("mainMenu");	
		}
	}
	
	void OnGUI(){
			GUI.DrawTexture(new Rect(0,0,finalSceneImage.width, finalSceneImage.height), finalSceneImage, ScaleMode.StretchToFill);
	}
}
