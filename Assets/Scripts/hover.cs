using UnityEngine;
using System;
using System.Collections;

public class hover : MonoBehaviour {

	private bool onHover = false;
	private Vector3 originalSize = Vector3.zero;
	public GameObject testCube;

	bool down = false;
	bool held = false;
	bool up = false;


	// Use this for initialization
	void Start () {
		originalSize = transform.localScale;
		//testCube = GameObject.Find("Cube");
		testCube = GameObject.Find("Cube");

		//support touchpad
//		OVRTouchpad.Create();
//		OVRTouchpad.TouchHandler += HandleTouchHandler;
	
	}

//	private void HandleTouchHandler(object sender, EventArgs e)
//	{
//		var touchArgs = (OVRTouchpad.TouchArgs) e;
//		if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap) {
//			Debug.Log ("Received SingleTap");
//		} else {
//			Debug.Log ("Received " + e);
//		}
//	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("++Enter");


		onHover = true;
		Vector3 onHoverSize = originalSize * 1.5f;
//		LeanTween.scale (testCube, onHoverSize, 1f).setEase (LeanTweenType.easeInSine);
		//transform.localScale = transform.localScale * 1.5f;

		SetColor (Color.red);

	}

	void OnTriggerExit(Collider Col){
		Debug.Log ("++Exit");
		transform.localScale = originalSize;
		onHover = false;
	}

	void SetColor(Color aColor){
		GetComponent<Renderer> ().material.color = aColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (onHover) {

			down = Input.GetKeyDown (KeyCode.Space);
			held = Input.GetKey (KeyCode.Space);
			up = Input.GetKeyUp (KeyCode.Space);

			if (held || down){
				Debug.Log ("++Down");
				SetColor (Color.black);
			} else if (up) {
				Debug.Log("++Up");
				SetColor (Color.white);
			}
			
		}	
	
	}
}
