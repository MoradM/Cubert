using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	
	public GameObject[] bullets;
	
	private bool hasEntered=false;
	private bool hasFired=false;
	
//	private Vector3 pos;
	public float xNewPos;
	
	void Start () {
	//	pos = bullet.transform.localPosition;
	//	pos.x = xNewPos;
	}
	
	
	void Update () {
		if(hasEntered){
			if(Input.GetKeyDown(KeyCode.K)){
				hasFired=true;
				print ("Fired");
			}
		}
		
		if(hasFired){
			
			foreach(GameObject bul in bullets){
				Vector3 newPos = bul.transform.localPosition;
				newPos.x = xNewPos;
				bul.transform.localPosition = Vector3.Lerp(bul.transform.localPosition, newPos, 10f*Time.deltaTime);	
			}
			
			StartCoroutine(destroyBullets ());
			
			
			//bullet.transform.localPosition = Vector3.Lerp(bullet.transform.localPosition, pos, Time.deltaTime * 20f);
		}
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag== "Player"){
			hasEntered=true;
			print ("Entered");
		}
		
		
	}
	
	IEnumerator destroyBullets(){
		
	
		
		yield return new WaitForSeconds(5.0f);
		
			hasEntered=false;
		hasFired=false;
		
		foreach(GameObject bul in bullets)
			DestroyObject(bul);
		
	}	
}
