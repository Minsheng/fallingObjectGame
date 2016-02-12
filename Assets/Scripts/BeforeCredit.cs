using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeforeCredit : MonoBehaviour {

	// load last level
	public void onNext() {
		StartCoroutine (FadeAndLoad (SceneManager.GetActiveScene().buildIndex+1));
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
