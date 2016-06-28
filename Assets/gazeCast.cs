using UnityEngine;
using System.Collections;

public class gazeCast : MonoBehaviour {

	public Camera headCamera;
	public Transform cursorLoc;
	public IGazeable seenObj, currObj = null;
	public int layerMask1;

	private GameObject platform, flower; 



	// Use this for initialization
	void Start () {
		platform = GameObject.FindGameObjectWithTag ("platform");
		flower = GameObject.Find("Flower");

	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		Debug.DrawRay (transform.position, fwd*15);

		//if there is no flower set, then the flower is the only gazable object
		//otherwise any droppable area can be hit


//		int layerMask1 = (int)GameManager.layerMasks.flower;

		if (GameManager.pickedUp) {
			layerMask1 = (int)GameManager.layerMasks.droppable;
			platform.layer = (int)GameManager.layerBits.droppable;
			flower.layer = (int)GameManager.layerBits.ignoreRaycast;
		}
		else{
			flower.layer = (int)GameManager.layerBits.flower;
			layerMask1 = (int)GameManager.layerMasks.flower;
			platform.layer = (int)GameManager.layerBits.ignoreRaycast;

		}

		if (Physics.Raycast (transform.position, fwd, out hit,layerMask1)) {
//			Debug.Log ("this is layer mask " + layerMask1.ToString());
			seenObj = hit.transform.GetComponent<IGazeable> ();
			if (seenObj != null) {

				seenObj.onGazeEnter ();
				currObj = seenObj;

			} else{ 
				if (seenObj == null) {
//					Debug.Log ("SeenObj is Null");
				} else if (currObj == null) {
//					Debug.Log ("CurrObj is Null");
				} 

				if (currObj != null) {
					Debug.Log ("CurrObj is " + currObj.ToString());

					currObj.onGazeExit ();
					currObj = null;
				}
			} 
//			Debug.Log ("hit " + hit.collider.gameObject.name);

		}
	
	}
}
