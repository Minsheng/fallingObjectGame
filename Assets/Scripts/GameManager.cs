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

	// Update is called once per frame
//	void Update () {
//		if (!gameStarted && Time.timeScale == 0) {
//
//			if(Input.anyKeyDown){
//
//				timeManager.ManipulateTime(1, 1f);
//				ResetGame();
//			}
//		}
//
//		if (!gameStarted) {
//			blinkTime ++;
//
//			if (blinkTime % 40 == 0) {
//				blink = !blink;
//			}
//
//			continueText.canvasRenderer.SetAlpha (blink ? 0 : 1);
//
//			var textColor = beatBestTime ? "#FF0" : "#FFF";
//
//			scoreText.text = "TIME: " + FormatTime (timeElapsed) + "\n<color="+textColor+">BEST: " + FormatTime (bestTime)+"</color>";
//		} else {
//			timeElapsed += Time.deltaTime;
//			scoreText.text = "TIME: "+FormatTime(timeElapsed);
//		}
//	}
//
//	void OnPlayerKilled(){
//		spawner.active = false;
//
//		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
//		playerDestroyScript.DestroyCallback -= OnPlayerKilled;
//
//		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
//		timeManager.ManipulateTime (0, 5.5f);
//		gameStarted = false;
//
//		continueText.text = "PRESS ANY BUTTON TO RESTART";
//
//		if (timeElapsed > bestTime) {
//			bestTime = timeElapsed;
//			PlayerPrefs.SetFloat("BestTime", bestTime);
//			beatBestTime = true;
//		}
//	}
//
//	void ResetGame(){
//		spawner.active = true;
//
//		player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height/PixelPerfectCamera.pixelsToUnits)/2 + 100, 0));
//
//		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
//		playerDestroyScript.DestroyCallback += OnPlayerKilled;
//
//		gameStarted = true;
//
//		continueText.canvasRenderer.SetAlpha(0);
//
//		timeElapsed = 0;
//		beatBestTime = false;
//	}
//
//	string FormatTime(float value){
//		TimeSpan t = TimeSpan.FromSeconds (value);
//
//		return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
//	}
}
