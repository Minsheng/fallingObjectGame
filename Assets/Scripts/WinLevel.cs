using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour {

	private int nextLevel;

	void Awake() {
		nextLevel = PlayerPrefs.GetInt ("winLevel");	
	}

	// load last level
	public void onNext() {
		StartCoroutine (FadeAndLoad (nextLevel));
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
