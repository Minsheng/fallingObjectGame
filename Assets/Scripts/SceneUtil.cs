using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneUtil : MonoBehaviour {

	private IEnumerator FadeAndLoad(int scene) {
		float fadeTime = GameObject.Find ("SceneManager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (scene);
	}
}
