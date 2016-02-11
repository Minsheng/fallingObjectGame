using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	private int maxHealth = 5;
	public GameObject health;
	public Texture[] healthImages;
	private int currentHealth;
	private GameObject healthClone;

	public float PREFAB_WIDTH = 30;
	public float PREFAB_HEIGHT = 30;

//	private float spacingX;

	void Start () {
		currentHealth = maxHealth;
		initHealth();
	}

	void initHealth() {
		healthClone = GameObjUtil.InitRelateToParent(health, 
			GameObject.Find("HUDCanvas"), new Vector3());
	}

	public void ReduceHealth(int amount) {
		currentHealth -= amount;
		healthClone.GetComponent<RawImage>().texture = healthImages [currentHealth-1];
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Platform"))
		{
			if (this.currentHealth > 1) {
				ReduceHealth (1);
				Debug.Log ("Remaining health:" + this.currentHealth);
			} else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
