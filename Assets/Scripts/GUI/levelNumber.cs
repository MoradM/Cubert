using UnityEngine;
using System.Collections;

public class levelNumber : MonoBehaviour {
	
	public Texture LevelImage;
	
	bool show=false;
	// Use this for initialization
	void Start () {
		StartCoroutine (showTimer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		if(show){
			GUI.Box (new Rect(Screen.width/2 - LevelImage.width/2, Screen.height/2 - LevelImage.height/2, LevelImage.width, LevelImage.height ), LevelImage);	
		}
	}
	
	IEnumerator showTimer(){
		show=true;	
		
		yield return new WaitForSeconds(4);
		
		show=false;
	}
}
