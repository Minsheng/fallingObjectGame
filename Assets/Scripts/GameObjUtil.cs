using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjUtil : MonoBehaviour {

	private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool> ();

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

	public static void Destroy(GameObject gameObject){

		var recyleGameObject = gameObject.GetComponent<RecycleGameObject> ();

		if (recyleGameObject != null) {
			recyleGameObject.Shutdown ();
		} else {
			GameObject.Destroy (gameObject);
		}
	}

	private static ObjectPool GetObjectPool(RecycleGameObject reference){
		ObjectPool pool = null;

		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else {
			var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
			pool = poolContainer.AddComponent<ObjectPool>();
			pool.prefab = reference;
			pools.Add (reference, pool);
		}

		return pool;
	}
}
