using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	
	
	
	// These variables are for adjusting in the inspector how the object behaves 
	public float maxSpeed  = 5;
	public float force     = 8;
	public float jumpSpeed = 5;
	public float speed = 5;
	public Transform cam;
	
	// These variables are there for use by the script and don't need to be edited
	private int state = 0;
	private bool grounded = false;
	private float jumpLimit = 0;
	private Rigidbody rb;
	// Don't let the Physics Engine rotate this physics object so it doesn't fall over when running
	void Awake ()
	{ 
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;

	}
	
	// This part detects whether or not the object is grounded and stores it in a variable
	void OnCollisionEnter ()
	{
		state ++;
		if(state > 0)
		{
			grounded = true;
		}
	}
	
	
	void OnCollisionExit ()
	{
		state --;
		if(state < 1)
		{
			grounded = false;
			state = 0;
		}
	}
	
	
	public bool jump
	{
		get 
		{
			return Input.GetButtonDown ("Jump");
		}
	}
	/*
	public float horizontal
	{
		get
		{
			return Input.GetAxis("Horizontal") * force;
		} 
	} 
	public float vertical
	{
		get
		{
			return Input.GetAxis("Vertical") * force;
		} 
	}
	*/
	// This is called every physics frame
	void Update ()
	{
		transform.LookAt (cam);
		/*cam = gameObject.GetComponentInChildren<Camera>();

		transform.Rotate = cam.gameObject.transform.Rotate;*/
		//transform.rotation = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0);


		float tempSpeedX = rb.velocity.x;
		float tempSpeedZ = rb.velocity.z;
		if(Input.GetAxis("Vertical") > 0)
		{
			rb.velocity += transform.forward * speed * Time.deltaTime;
			//tempSpeedZ += Input.GetAxis("Vertical") * speed * Time.deltaTime;
			

		}
		if(Input.GetAxis("Vertical") < 0)
		{
			rb.velocity += transform.forward * -1f * speed * Time.deltaTime;
			//tempSpeedZ += Input.GetAxis("Vertical") * speed * Time.deltaTime;
			
			
		}

		if(Input.GetAxis("Horizontal") > 0)
		{
			rb.velocity += transform.right  * speed * Time.deltaTime;
			//tempSpeedX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			

		}
		if(Input.GetAxis("Horizontal") < 0)
		{
			rb.velocity += transform.right * -1f * speed * Time.deltaTime;
			//tempSpeedX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			
			
		}
		//rb.velocity = new Vector3(Mathf.Clamp(tempSpeedX,maxSpeed * -1, maxSpeed),0,Mathf.Clamp(tempSpeedZ,maxSpeed * -1, maxSpeed));


/*

		
		// If the object is grounded and isn't moving at the max speed or higher apply force to move it
		if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && grounded == true)
		{
			rb.velocity = new Vector3(0,0,10);
			//GetComponent<Rigidbody>().velocity (transform.rotation * Vector3.right * horizontal);
		}*/

		
	
	}
	void FixedUpdate(){
		// This part is for jumping. I only let jump force be applied every 10 physics frames so
		// the player can't somehow get a huge velocity due to multiple jumps in a very short time
		if (jumpLimit < 10)
			jumpLimit ++;
		
		if (jump && grounded) {
			GetComponent<Rigidbody> ().AddForce (0, 10, 0);
			jumpLimit = 0;
		}
		//rb.AddRelativeForce(Vector3.forward * speed);
	}
	
}