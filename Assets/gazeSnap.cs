using UnityEngine;
using System.Collections;

public class gazeSnap : MonoBehaviour {

	float flDistance;
	GameObject flower = null, cursor = null;
	float flDistance2,fly, flz;
	float curry, currz;

	// Use this for initialization
	void Start () {

		flower = GameObject.Find ("Flower");
		cursor = GameObject.Find ("Cursor");



		if (flower != null) {
//			flDistance = Vector3.Distance (flower.transform.position, transform.position);
//			Debug.Log ("flDistance: " + flDistance.ToString());

		}
	}
	
	// Update is called once per frame
	void Update () {
		flDistance = Vector3.Distance (flower.transform.position, cursor.transform.position);

//		Debug.Log ("fl3: " + flDistance.ToString());



	
	}
}
