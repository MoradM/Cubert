using UnityEngine;
using System.Collections;

public class rgb : MonoBehaviour {

	public int indicator;
	
	void Start () {
	
	}
	
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag=="Player"){
			rgbChecker.sequence.Add(indicator);
		}
	}
}
