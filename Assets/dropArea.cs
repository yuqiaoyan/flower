using UnityEngine;
using System;
using System.Collections;

public class dropArea : MonoBehaviour {

	public GameObject transparentFlower = null;
	private GameObject head = null;
	public Renderer tFlowerRend,flowerRend;
	public GameObject prototype = null;

	bool droppable = false;

	bool down = false;
	bool leftClick = false;

	// Use this for initialization
	void Start () {
		
		if (transform.GetChild (0).gameObject) {
			transparentFlower = transform.GetChild (0).gameObject;
			tFlowerRend = transparentFlower.GetComponent<Renderer> ();
			tFlowerRend.enabled = false;

			//dropLocation = transparentFlower.transform.position;
		}

	
	}

	void OnTriggerEnter(Collider col){

		head = GameObject.Find ("Head Tabletop");

		if (head != null) {

			if (head.transform.Find ("Flower") != null) {
					//show transparent flower
					tFlowerRend.enabled = true;
					droppable = true;
					GameManager.dropLocation = transparentFlower.transform.position;

			}
				
		}
			


	}

	void OnTriggerExit(Collider Col){
		Debug.Log ("++DropArea Exit");
		tFlowerRend.enabled = false;
		droppable = false;
		GameManager.dropLocation = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {

		down = Input.GetKeyDown (KeyCode.Space);
		leftClick = Input.GetMouseButton (0);

		if (droppable == true) {
			GameObject flower = GameObject.Find ("Head Tabletop").transform.Find ("Flower").gameObject;

			if (GameManager.currScene == GameManager.scenes.proto2Input) {
				//protoype for left click or spacebar down
				if (leftClick || down) {

					tFlowerRend.enabled = false;

					//				flower.GetComponent<hoverFlower> ().dropStartTrick (dropLocation);


				}

				droppable = false;
			} else if(GameManager.currScene==GameManager.scenes.proto1Snap){
				Material flowerMat = flower.GetComponent<Renderer> ().material;
				Utilities.setAlpha (flowerMat, 1F);
	
				flower.transform.position = GameManager.dropLocation;
			}








		}

	
	}
}
