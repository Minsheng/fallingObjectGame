using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public static GameObject player;
	private float xOffset = 0;
	private float yOffset = 8;
	private float zOffset = 0;
	private Vector3 offset;

	/* manually set the starting position */
	void Start ()
	{
		offset = transform.position + new Vector3(xOffset, yOffset, zOffset);
	}

	void LateUpdate ()
	{
		if (player) {
			transform.position = player.transform.position + offset;
		}
	}

}