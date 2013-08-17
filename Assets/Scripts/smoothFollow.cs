using UnityEngine;
using System.Collections;

public class smoothFollow : MonoBehaviour {
	
	public Transform character;
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;
	
	bool crossedWall=false;
	Color beginColor;
	// Use this for initialization
	void Start () {
		GameObject wall = GameObject.FindGameObjectWithTag("lookThrough");
		beginColor = wall.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 wantedPos;
		
		if(followBehind)
			wantedPos =character.TransformPoint(0,height, -distance);
		
		else
			wantedPos = character.TransformPoint(0, height, distance);
		
		transform.position = Vector3.Lerp (transform.position, wantedPos, Time.deltaTime * damping);
		
		if(smoothRotation){
			Quaternion wantedRot = Quaternion.LookRotation(character.position - transform.position, character.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRot, Time.deltaTime * rotationDamping);
		}
		
		else
			transform.LookAt (character,character.up);
		
		
		//This is for fading out wall
			if(transform.position.z > 3.0f){
				GameObject wall = GameObject.FindGameObjectWithTag("lookThrough");
				Color col = wall.renderer.material.color;
				col.a = 0.120f;
				wall.renderer.material.color = col;
				crossedWall=true;
			print ("went in");
		}
		
		else{
			if(crossedWall){
				GameObject wall = GameObject.FindGameObjectWithTag("lookThrough");
				wall.renderer.material.color=beginColor;
				crossedWall=false;
				print ("went out");
			}
		}
		//End fading out wall
	}
}
