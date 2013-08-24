using UnityEngine;
using System.Collections;

public class gravPlat : MonoBehaviour {
	
	private bool move=false;

	public GameObject platform;
	
	private Vector3 moveToPlat;
	private Vector3 moveToTrigger;
	
	private Vector3 initPlat;
	private Vector3 initTrigger;
	
	public float speed= 0.05f;
	// Use this for initialization
	void Start () {
		
		initPlat = platform.transform.position;
		initTrigger = transform.position;
		
		moveToPlat = platform.transform.position;
		moveToPlat.y = moveToPlat.y - 3.0f;
		
		moveToTrigger = transform.position;
		moveToTrigger.y = moveToTrigger.y - 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(move){
			platform.transform.position = Vector3.Lerp(platform.transform.position, moveToPlat, speed * Time.deltaTime);
			transform.position = Vector3.Lerp(transform.position, moveToTrigger, speed * Time.deltaTime);
		}
		
		else{
			platform.transform.position = Vector3.Lerp (platform.transform.position, initPlat, speed * 1.5f  * Time.deltaTime);
			transform.position = Vector3.Lerp (transform.position, initTrigger, speed * 1.5f  * Time.deltaTime);
		}
	}
	
	void OnTriggerStay(Collider c){
		if(c.tag=="Player"){
			move=true;
		}
	}
	
	void OnTriggerExit(Collider c){
		if(c.tag == "Player"){
			move=false;	
		}
	}
}
