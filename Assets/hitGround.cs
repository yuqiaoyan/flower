using UnityEngine;
using System.Collections;

public class hitGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){


		if (col.gameObject.CompareTag ("flower")) {
			Debug.Log ("++Hit Ground Enter");
			col.GetComponent<Rigidbody> ().isKinematic = true;
			col.GetComponent<Rigidbody> ().useGravity = false;

		};
			
	}

}
