using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public int initHealth = 3;
	public GameObject heartGUI;
	private List<GameObject> hearts = new List<GameObject>();
	private int currentHealth;

	public float PREFAB_WIDTH = 30;
	public float PREFAB_HEIGHT = 30;

	private float spacingX;

	void Start () {
		currentHealth = initHealth;

		spacingX = PREFAB_WIDTH+5;

		AddHealth(initHealth); // initialize health
	}

	/* generate health */
	public void AddHealth(int n) {
		for (int i = 0; i < n; i++) {
			GameObject healthClone = Instantiate(heartGUI);
			healthClone.transform.SetParent (GameObject.Find("HUDCanvas").transform, false); // attach to the HUDCanvas
			healthClone.transform.localPosition += new Vector3 ((i+1)*spacingX, 0, 0); // position each heart with spacing
			hearts.Add(healthClone);
		}
	}

	public void ReduceHealth(int amount) {
		currentHealth -= amount;
		UpdateHearts ();
	}

	private void UpdateHearts() {
		Destroy (hearts.Last());
		hearts.Remove (hearts.Last());
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Platform"))
		{
			if (this.currentHealth > 0) {
				ReduceHealth (1);
				Debug.Log ("Remaining health:" + this.currentHealth);
			} else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
