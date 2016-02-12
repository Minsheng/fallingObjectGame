using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public int maxHealth;
	public float speed;
	public float torque;
	public bool isFlippable = false;
	public float gravity = 9.81f;
	private Vector3 upVector = new Vector3 (0, 1, 0); // The upwards vector, default is +y
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false; // disable the default gravity
	}

	void FixedUpdate ()
	{
		/* manually apply gravity to the game object */
		rb.velocity -= (upVector * gravity) * Time.deltaTime;

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
		int nextLevel = SceneManager.GetActiveScene ().buildIndex+1;

		if (other.gameObject.CompareTag ("Level1EndingTrigger") || 
			other.gameObject.CompareTag ("Level2EndingTrigger"))
		{
			PlayerPrefs.SetInt ("winLevel", nextLevel);
			SceneManager.LoadScene("PlayerWin");
		}

		if (other.gameObject.CompareTag ("Level3EndingTrigger"))
		{
			SceneManager.LoadScene("LevelCleared");
		}
	}


		


}
