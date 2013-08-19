using UnityEngine;
using System.Collections;

public class mainmenu : MonoBehaviour {

	public Texture logo;
	
	public Texture continueDisabled;
	
	public Texture playStatic;
	public Texture quitStatic;
	public Texture continueStatic;
	
	private Rect playPos;
	private Rect continuePos;
	private Rect quitPos;
	
	public Texture playHover;
	public Texture quitHover;
	public Texture continueHover;
	
	
	void Start () {
		playPos = new Rect(Screen.width/2 - playStatic.width/2, 4* playStatic.height, playStatic.width, playStatic.height);
		continuePos = new Rect(Screen.width/2 - continueStatic.width/2, 6* continueStatic.height, continueStatic.width, continueStatic.height);
		quitPos = new Rect(Screen.width/2 - quitStatic.width/2, 8* quitStatic.height, quitStatic.width, quitStatic.height);
	}
	
	// Update is called once per frame
	void Update () {	
	}
	
	void OnGUI(){
		//draw bg
		Texture2D rect = new Texture2D(1,1);
		rect.SetPixel (0,0, Color.black);
		rect.Apply();
		GUI.skin.box.normal.background = rect;
		GUI.Box (new Rect(0,0,Screen.width,Screen.height), GUIContent.none);
		//END draw bg
		
		//draw logo, play button and quit button
		GUI.DrawTexture(new Rect(Screen.width/2 - logo.width/2, logo.height/2, logo.width, logo.height), logo);
		
		if(PlayerPrefs.HasKey("LevelReached")){
			GUI.DrawTexture (continuePos,continueStatic);	
		}
		else
			GUI.DrawTexture(continuePos,continueDisabled);
		
		GUI.DrawTexture (playPos, playStatic);	
		GUI.DrawTexture (quitPos,quitStatic);
		
		
		Event hit = Event.current;
		
		if(playPos.Contains (hit.mousePosition)){
			GUI.DrawTexture (playPos, playHover);
			
			if(Input.GetMouseButtonDown (0)){
				Application.LoadLevel("scene1");
			}
			
		}
		else{
			GUI.DrawTexture(playPos,playStatic);	
		}
		
		if(PlayerPrefs.HasKey("LevelReached")){
			if(continuePos.Contains(hit.mousePosition)){
				GUI.DrawTexture(continuePos, continueHover);
				if(Input.GetMouseButtonDown (0)){
					Application.LoadLevel(PlayerPrefs.GetString ("LevelReached"));
				}
			}
			else{
				GUI.DrawTexture (continuePos, continueStatic);
			}
		}
		
		if(quitPos.Contains (hit.mousePosition)){
			GUI.DrawTexture (quitPos, quitHover);
			
			if(Input.GetMouseButtonDown(0)){
				Application.Quit();	
			}
			
		}
		else{
			GUI.DrawTexture (quitPos, quitStatic);
		}
		
	}

}
