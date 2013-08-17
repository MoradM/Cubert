using UnityEngine;
using System.Collections;

public class switchLevels : MonoBehaviour {
	
	public string levelName;
	private bool hasTriggered = false;
	
	
	void Start () {
		if(!Application.loadedLevelName.Equals("mainMenu"))
			PlayerPrefs.SetString("LevelReached", Application.loadedLevelName);
	}
	
	
	void Update () {
		if(hasTriggered){
			Application.LoadLevel(levelName);
		}
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag=="Player")
			hasTriggered=true;
	}
}
