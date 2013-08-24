using UnityEngine;
using System.Collections;

public class rgbChecker : MonoBehaviour {
	
	public static ArrayList sequence = new ArrayList();
	
	private bool finished=false;
	
	public GameObject platform;
	public Vector3 to;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(sequence.Count>0 & !finished)
			check ();
		
		if(finished)
			platform.transform.position = Vector3.Lerp(platform.transform.position, to, 0.05f * Time.deltaTime);
		
	}	
	
	void check(){
		if(sequence.Count > 2){
			for(int i=0; i<sequence.Count; i++){
				if(i+2 < sequence.Count ){
					if(((int)sequence[i])==1 & ((int)sequence[i+1])==2 & ((int)sequence[i+2])==3){
						finished=true;
						
					}
				}
			}
		}
	}
}
