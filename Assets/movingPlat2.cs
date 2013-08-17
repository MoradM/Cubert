using UnityEngine;
using System.Collections;

public class movingPlat2 : MonoBehaviour {
	
	Vector3 origPos;	
	bool moveForward=true;
	bool moveBack=false;
	// Use this for initialization
	void Start () {
		origPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(moveForward){
			Vector3 tmpPos = transform.localPosition;
			tmpPos.z+= 0.05f;
			transform.localPosition = tmpPos;
			print ("im here");
		}
		 if(moveBack){
			Vector3 tmpPos = transform.localPosition;
			tmpPos.z -= 0.05f;
			transform.localPosition = tmpPos;
			print ("I'm in moveBack");
		}
	}
	
	void OnCollisionEnter(Collision col){
	//	if(col.transform.tag=="platformBlock"){
			if(col.transform.position.z < transform.localPosition.z){
				moveForward=false;
				moveBack=true;
			print ("Collided with something");
			}
			else if(col.transform.position.z > transform.localPosition.z & !moveForward){
				moveForward=true;
				moveBack = false;
			}
	//	}
	}
}
