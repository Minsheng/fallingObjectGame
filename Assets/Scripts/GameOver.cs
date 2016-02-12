using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	private int prevLevel;

	void Awake() {
		prevLevel = PlayerPrefs.GetInt ("failedLevel");	
	}

	// load last level
	public void onRetry() {
		if (prevLevel != 0) {
			StartCoroutine (FadeAndLoad (prevLevel));
		}
	}

	// back to main menu
	public void onBack() {
		StartCoroutine (FadeAndLoad(1));
	}

	private IEnumerator FadeAndLoad(int scene) {
		float fadeTime = GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (scene);
	}
}
