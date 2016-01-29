using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float torque;
	public bool isFlippable = false;

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

		if (isFlippable) {
			rb.AddTorque(-transform.up * torque * moveHorizontal, ForceMode.VelocityChange);
			rb.AddTorque(transform.right * torque * moveVertical, ForceMode.VelocityChange);
		}

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Platform"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (other.gameObject.CompareTag ("Level1EndingTrigger"))
		{
			SceneManager.LoadScene(2);
		}
	}


		


}
