using UnityEngine;
using System;
using System.Collections;

public class hoverFlower : MonoBehaviour, IGazeable {


	public GameObject glowOrb;
	public Renderer glowRend;


	// Use this for initialization
	void Start () {

		//support touchpad
		glowOrb = transform.GetChild (0).gameObject;
		glowRend = glowOrb.GetComponent<Renderer>();
		glowRend.enabled = false;

		//OVRTouchpad.Create();
		//OVRTouchpad.TouchHandler += HandleTouchHandler
	
	}

	public void onGazeEnter(){

//		Debug.Log ("++flower gazeEnter");
		glowRend.enabled = true;

		this.GetComponent<ParticleSystem> ().Clear ();
		this.GetComponent<ParticleSystem> ().Stop ();

		GameManager.onGaze = true;

		
	}

	public void onGazeExit(){
		//Debug.Log ("++flower gazeExit");
		GameManager.onGaze = false;
		if (GameManager.pickedUp == false) {
			glowRend.enabled = false;
		}
	}

	public void dropFlower(){
		if (GameManager.dropLocation != Vector3.zero) {
			transform.position = GameManager.dropLocation;
			GameManager.dropLocation = Vector3.zero;
			glowRend.enabled = false;

		} else {
			Utilities.addGravity (this.GetComponent<Rigidbody> ());
		}

		GameManager.pickedUp = false;
		GameManager.onGaze = false;
		transform.parent = null;
		GameManager.dropLocation = Vector3.zero;
	}

	public void pickUpFlower(){
		if (GameManager.onGaze) {
			Debug.Log ("++Pick Up Flower");

			this.transform.parent = GameObject.Find ("Head Tabletop").transform;
			transform.localPosition = new Vector3 (0, -0.08f, 5.04f);

			GameManager.pickedUp = true;

			Material tempCursor = GameObject.Find ("Cursor").GetComponent<Renderer> ().material;
			Utilities.setAlpha (tempCursor, 0.4F);

		}
		glowRend.enabled = false;
	}


		
		
	
	// Update is called once per frame
	void Update () {
	}
}
