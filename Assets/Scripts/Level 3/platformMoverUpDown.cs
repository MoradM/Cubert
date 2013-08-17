using UnityEngine;
using System.Collections;

public class platformMoverUpDown : MonoBehaviour {
	
	Vector3 origPos;
	Vector3 tmpPos;
	bool moveUp=false;
	bool moveDown=true;
	
	// Use this for initialization
	void Start () {
		origPos = gameObject.transform.localPosition;
		tmpPos = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(moveDown){
			tmpPos.y -= 0.05f;
			transform.localPosition = tmpPos;
		}
		 if  (moveUp){
			print ("Gotta move up");
			tmpPos.y += 0.05f;
			transform.localPosition = tmpPos;
		}
	}
	
	void OnCollisionEnter(Collision col){
		if(col.transform.tag =="platformBlock"){
			if(col.transform.localPosition.y 	> origPos.y & !moveDown){
					moveDown=true;
					moveUp = false;
			}
			if(col.transform.localPosition.y < origPos.y & !moveUp){
				moveUp=true;
				moveDown=false;
			}
		}
	}
}
