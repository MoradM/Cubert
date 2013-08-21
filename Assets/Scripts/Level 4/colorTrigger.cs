using UnityEngine;
using System.Collections;

public class colorTrigger : MonoBehaviour {

	public GameObject platformToAffect;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			if(col.renderer.material.color != platformToAffect.renderer.material.color)
				platformToAffect.collider.isTrigger=true;
			else
				platformToAffect.collider.isTrigger=false;
		}
	}
}
