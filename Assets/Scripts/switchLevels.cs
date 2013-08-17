using UnityEngine;
using System.Collections;

public class switchLevels : MonoBehaviour {
	
	public string levelName;
	private bool hasTriggered = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hasTriggered)
			Application.LoadLevel(levelName);
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag=="Player")
			hasTriggered=true;
	}
}
