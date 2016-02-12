using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	
	public GameObject health;
	public Texture[] healthImages;
	private int currentHealth;
	private GameObject healthClone;

	public float PREFAB_WIDTH = 120;
	public float PREFAB_HEIGHT = 120;

	void Start () {
		currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().maxHealth;
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
//				Debug.Log ("Remaining health:" + this.currentHealth);
			} else {
				// record the level where player fail
				PlayerPrefs.SetInt ("failedLevel", SceneManager.GetActiveScene().buildIndex);

				int characterType = PlayerPrefs.GetInt ("character");

				switch(characterType) {
				case 1: // bread
					SceneManager.LoadScene("PlayerDeathBread");
					break;
				case 2: // hammer
					SceneManager.LoadScene("PlayerDeathHammer");
					break;
				default:
					SceneManager.LoadScene("MainMenu");
					break;
				}

			}
		}
	}
}
