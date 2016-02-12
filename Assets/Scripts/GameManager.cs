using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public GameObject[] playerPrefab; // list that holds character prefabs
	public static GameObject playerObject; // player instance
	private int characterType; // 1: Bread, 2: Hammer
	private bool gameStarted;
	private PlayMusic playMusic;

	void Awake(){
		// get the character type set from Character Selection Menu
		characterType = PlayerPrefs.GetInt ("character");
		Debug.Log ("The current character is : " + characterType);
//		playMusic = GetComponent<PlayMusic> ();
	}

	// Use this for initialization
	void Start () {
		initPlayer ();

		// do not restart the background music
//		DontDestroyOnLoad(playMusic);
	}

	void initPlayer() {
		if (characterType != 0) {
			playerObject = GameObject.Instantiate (playerPrefab [characterType-1]);	
		} else {
			playerObject = GameObject.Instantiate (playerPrefab[0]);
		}

		// attach camera to player
		CameraController.player = playerObject;
	}
}
