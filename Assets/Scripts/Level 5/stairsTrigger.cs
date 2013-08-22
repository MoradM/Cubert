using UnityEngine;
using System.Collections;

public class stairsTrigger : MonoBehaviour {
	
	public GameObject platform;
	private Vector3 position2;
	public float newPositionX;
	private bool hasEntered=false;
	

	
	// Use this for initialization
	void Start () {
		position2 = platform.transform.localPosition;
		position2.x = newPositionX;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(hasEntered){

			platform.transform.localPosition = Vector3.Lerp(platform.transform.localPosition, position2, Time.deltaTime * 2f);

		}
	}
	
	void OnTriggerEnter(Collider c){
		if(!hasEntered){
			if(c.tag == "Player"){
				hasEntered=true;
			}
		}
	}
}
