using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class VideoController : MonoBehaviour {

	private MovieTexture movie;
	// Use this for initialization
	void Start () {
		movie = GetComponent<Renderer>().material.mainTexture as MovieTexture;
		GetComponent<AudioSource>().clip = movie.audioClip;

		GetComponent<AudioSource>().Play ();
		movie.Play ();

		StartCoroutine(WaitAndLoad(27f, 1));

	}
	
	// Update is called once per frame
	void Update () {
		// if space is pressed, instantly load next scene
		if (Input.GetKeyDown("space")) {
			movie.Stop ();
			StartCoroutine(WaitAndLoad(0, SceneManager.GetActiveScene().buildIndex+1));
		}
	}
		
	private IEnumerator WaitAndLoad(float value, int scene) {
		yield return new WaitForSeconds(value);
		float fadeTime = GameObject.Find ("SceneManager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (scene);
	}


}

