using UnityEngine;
using System.Collections;

public class hintsScript : MonoBehaviour {
	
	public Texture TextureToShow;
	bool hasCollided = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			hasCollided = true;
		}
			
	}
	
	void OnTriggerExit(Collider c){
		if(c.tag == "Player"){
			hasCollided=false;	
		}
	}
	
	
	void OnGUI(){
		if(hasCollided){
			if(!TextureToShow){
					Debug.LogError ("Assign a texture in the insepctor for " + gameObject.name) ;
					return;
			}
			
			GUI.DrawTexture (new Rect(Screen.width / 2 - TextureToShow.width / 2, Screen.height - TextureToShow.height - 15.0f, TextureToShow.width, TextureToShow.height), TextureToShow, ScaleMode.ScaleToFit,true, 0.0f);
		}
	}
}
