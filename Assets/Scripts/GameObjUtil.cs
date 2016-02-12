using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjUtil : MonoBehaviour {

	public static GameObject InitRelateToParent(GameObject prefab, GameObject parent, Vector3 diffPos){
		GameObject instance = null;

		instance = GameObject.Instantiate (prefab);

		if (instance) {
			if (parent) {
				instance.transform.SetParent (parent.transform, false);
				instance.transform.localPosition += diffPos;
			}
		}

		return instance;
	}
}
