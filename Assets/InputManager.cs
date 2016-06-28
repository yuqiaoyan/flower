using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	bool down = false;
	bool leftClick = false;
	public hoverFlower flower;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		down = Input.GetKeyDown (KeyCode.Space);
		leftClick = Input.GetMouseButton (0);

		//		if (down)
		//			Debug.Log ("Hit down");
		//		if (held)
		//			Debug.Log ("HELD");
		//		if (up)
		//			Debug.Log ("UP");

		if (down || leftClick) {

			//if flower is picked up, then either drop me on platform or on the ground
			if (GameManager.pickedUp) { 
				Debug.Log ("++Drop Flower Down");

				flower.dropFlower ();


				//if flower is not picked up and I'm being looked at, then pick me up!
			} else {
				flower.pickUpFlower ();

			}



		}

	
	}
		
}
