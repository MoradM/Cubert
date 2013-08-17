using UnityEngine;
using System.Collections;

public class movingPlatform1 : MonoBehaviour {

	
	Vector3 tmpPos;
	Vector3 origPos;
	bool movingRight=false;
	bool movingLeft=true;
	// Use this for initialization
	void Start () {
		tmpPos = gameObject.transform.localPosition;
		origPos = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
				tmpPos.x += 0.05f;
				transform.localPosition = tmpPos;
		}
		if(movingLeft){
			tmpPos.x -= 0.05f;	
			transform.localPosition = tmpPos;
		}
	}
	
	void OnCollisionEnter(Collision col){
		
			
			if(col.transform.localPosition.x < origPos.x){
				movingLeft=false;
				movingRight=true;
			}
			if(col.transform.localPosition.x > origPos.x & !movingLeft){
				movingRight = false;
				movingLeft = true;
			}
	}
	
	//void OnTriggerEnter(Collider c){
		
	//		if(c.transform.localPosition.x < origPos.x){
		//		movingLeft=false;
		//		movingRight=true;
			
			
	//		}
		//	if(c.transform.localPosition.x > origPos.x & !movingLeft){
		//		movingRight = false;
		//		movingLeft = true;
		//	}
//	}
}
