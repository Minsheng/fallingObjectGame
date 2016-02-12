using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour {
	public void onBack() {
		StartCoroutine (FadeAndLoad(1));
	}

	private IEnumerator FadeAndLoad(int scene) {
		float fadeTime = GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (scene);
	}
}
