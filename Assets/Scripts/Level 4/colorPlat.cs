using UnityEngine;
using System.Collections;

public class colorPlat : MonoBehaviour {

	public enum PlatformColor{
		blue,
		cyan,
		grey,
		magneta,
		red,
		white,
		yellow
	};
	
	public PlatformColor platColor;
	
	void Start () {
		//Set the color of the platform
			if(platColor==PlatformColor.blue)
				renderer.material.color = Color.blue;
			else if(platColor==PlatformColor.cyan)
				renderer.material.color = Color.cyan;
			else if(platColor==PlatformColor.grey)
				renderer.material.color = Color.grey;
			else if(platColor==PlatformColor.magneta)
				renderer.material.color = Color.magenta;
			else if(platColor==PlatformColor.red)
				renderer.material.color = Color.red;
			else if(platColor==PlatformColor.white)
				renderer.material.color = Color.white;
			else
				renderer.material.color = Color.yellow;			
	}
	
	
	void Update () {
	
	}
}
