using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Vector3 jump;
	public float jumpForce = 4.0f;
	public bool isGrounded;
    public float rotateDegree;
	Rigidbody rb;

	void Start(){
	  var xOLD = 0f;
		rb = GetComponent<Rigidbody> ();
		jump = new Vector3 (0.0f, 4.0f, 0.0f);
	}
	void OnCollisionEnter(){
		isGrounded = true;
	}
		
	void Update()
	{
		var xNEW = 0f;
		var xOLD = 0f;
		var x = 0f;
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		if (Input.GetKeyDown("a") && Input.GetKey ("w")) {
			xNEW = -1f * rotateDegree;
			x = (xOLD - xNEW) * -1;  
			transform.Rotate (0, x, 0);
			xOLD = xNEW;
		} else if (Input.GetKeyDown ("d") && Input.GetKey ("w")) {
			xNEW = rotateDegree;
			x = (xOLD - xNEW) * -1;  
			transform.Rotate (0, x, 0);
			xOLD = xNEW;
		}
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			rb.AddForce (jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
		transform.Translate(z, 0, 0);
	}
}
