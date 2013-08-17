using UnityEngine;
using System.Collections;

public class particleSystemFollowChar : MonoBehaviour {
	
	public GameObject character;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent = character.transform;
	}
}
