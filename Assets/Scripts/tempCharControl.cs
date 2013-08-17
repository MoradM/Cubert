using UnityEngine;
using System.Collections;

public class tempCharControl : MonoBehaviour {
	
	
	float speed = 4.0f;
	float jumpSpeed = 6.0f;
	float gravity = 20.0f;
	int jumpLimit = 30; //in frames
	int jumpLimitRefresh = 270; //in frames
	
	private Vector3 moveDirection = Vector3.zero;
	
	public Texture hoverOn;
	public Texture hoverOff;
	public Texture hoverCap;
	bool drawHoverCap = false;
	
	//For scaling
	public float scaleDuration = 1.5f;
	private bool isScaling = false;
	
	
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//FOR HOVERING
		if(jumpLimit==0){
				jumpLimitRefresh--;
					if(jumpLimitRefresh==0){
						jumpLimit=30;
						jumpLimitRefresh=270;
			}
		}
		//END FOR HOVERING
		
		
		CharacterController controller = gameObject.GetComponent<CharacterController>();
		
		if(controller.isGrounded){
			transform.Rotate(0, Input.GetAxis ("Rotate")*60.0f*Time.deltaTime,0);
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if(Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
			if(Input.GetButton ("Scale")){
				StartCoroutine(DoScale());
			}
			
			
		}
		
		
		//HOVER ACTUAL FUNCTION
		if(!controller.isGrounded){
			if(Input.GetButton("Hover")){
				if(jumpLimit!=0){
					moveDirection.y = jumpSpeed;
					
					//So that he won't jump accidentaly out of bounds
					//moveDirection.z = 0;
					
					jumpLimit--;
				}
				
			}
		}
		//END HOVER ACTUAL FUNCTION
		

		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		
		if(transform.localPosition.y < -7.0f)
			Application.LoadLevel(Application.loadedLevelName);
		
	}
	
	
	//SCALE FUNCTION
	
	public IEnumerator DoScale(){
		if(isScaling)
			yield break;
		isScaling = true;
		

		transform.localScale = Vector3.one / 3.0f;
		yield return new WaitForSeconds(3.0f);
		Vector3 tmpPos = transform.localPosition;
		tmpPos.y += 1.5f;
		transform.localPosition = tmpPos;
		
        // Snap the scale to 1.0
        transform.localScale = Vector3.one;
        // Declare that we are no longer modifing the scale.
        isScaling = false;
		
		
	}
	
	//END SCALE FUNCTION
	
	void OnGUI(){
		if(jumpLimit!=0)
			GUI.DrawTexture(new Rect(hoverOn.width + 3.0f, hoverOn.height + 3.0f, hoverOn.width, hoverOn.height), hoverOn, ScaleMode.ScaleToFit,true, 0.0f);
		else if(jumpLimit==0)
			GUI.DrawTexture(new Rect(hoverOff.width + 3.0f, hoverOff.height + 3.0f, hoverOff.width, hoverOff.height), hoverOff, ScaleMode.ScaleToFit,true, 0.0f);
		if(drawHoverCap)
			GUI.Box (new Rect(Screen.width / 2 - hoverCap.width/2, Screen.height/2 - hoverCap.height/2, hoverCap.width, hoverCap.height), hoverCap);
			
	}
	
	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "hoverCapsule"){
			
				jumpLimit = 1000;
				col.renderer.enabled=false;
				col.collider.enabled = false;
				GameObject hoverCapLight = GameObject.FindGameObjectWithTag("hoverCapsuleLight");
				hoverCapLight.GetComponent<Light>().intensity = 0.0f;
				StartCoroutine(drawHoverCapFunc());
		}
			
	}
	//void OnControllerColliderHit(ControllerColliderHit hit){

	//}
	
	IEnumerator drawHoverCapFunc(){
		drawHoverCap = true;
		yield return new WaitForSeconds(4.0f);
		drawHoverCap=false;
	}
}
