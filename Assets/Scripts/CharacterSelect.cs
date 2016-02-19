using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CharacterSelect : MonoBehaviour {

	public int sceneToStart = 1;										//Index number in build settings of scene to load if changeScenes is true
	public bool changeScenes;											//If true, load a new scene when Start is pressed, if false, fade out UI and continue in single scene
	public bool changeMusicOnStart;										//Choose whether to continue playing menu music or start a new music clip
	public int musicToChangeTo = 0;										//Array index in array MusicClips to change to if changeMusicOnStart is true.

	private PlayMusic playMusic;										//Reference to PlayMusic script

	void Awake() {
		//Get a reference to PlayMusic attached to UI object
		playMusic = GetComponent<PlayMusic> ();
	}

	// character 1: bread, 2: hammer
	public void characterOnClicked(int character) {
		// back button clicked, go back to previous scene
		if (character == 0) {
			playMusic.Stop ();

			StartCoroutine (FadeAndLoad (SceneManager.GetActiveScene ().buildIndex - 1));
		} else {
			// set the persistent data of character type
			PlayerPrefs.SetInt ("character", character);

			playMusic.Stop ();

			//Load the next scene
			StartCoroutine (FadeAndLoad(SceneManager.GetActiveScene().buildIndex+1));	
		}
	}

	private IEnumerator FadeAndLoad(int scene) {
		float fadeTime = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (scene);
	}
}
