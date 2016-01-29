using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float torque;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddTorque(-transform.up * torque * moveHorizontal, ForceMode.VelocityChange);
		rb.AddTorque(transform.right * torque * moveVertical, ForceMode.VelocityChange);
		rb.AddForce (movement * speed, ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Platform"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}


		


}
