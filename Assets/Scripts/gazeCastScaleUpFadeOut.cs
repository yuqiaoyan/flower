using UnityEngine;
using System.Collections;

public class gazeCastScaleUpFadeOut : MonoBehaviour {

	public Camera headCamera;
	public Transform cursorLoc;
	public IGazeable seenObj, currObj = null;
	public int layerMask1;
	public bool cursorReady = true;
	public float glowExpandDampen = 10f, flDistance, flDistance2;
	public Vector3 cursorEndPosition; 


	private GameObject platform, flower, glow, ground, cursorEnd;
	private float glowExpand = 0f;
	private Vector3 glowOriginalScale;







	// Use this for initialization
	void Start () {
		platform = GameObject.FindGameObjectWithTag ("platform");
		flower = GameObject.Find("Flower");
		glow = GameObject.Find ("flowerGlow");
		ground = GameObject.Find ("Ground");
		cursorEnd = GameObject.Find ("cursorEnd");

		glowOriginalScale = glow.transform.localScale;
		cursorEndPosition = cursorEnd.transform.position;


	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		Debug.DrawRay (transform.position, fwd*15);
		cursorEndPosition = cursorEnd.transform.position;

		//if there is no flower set, then the flower is the only gazable object
		//otherwise any droppable area can be hit


//		int layerMask1 = (int)GameManager.layerMasks.flower;

		if (GameManager.pickedUp) {
			layerMask1 = (int)GameManager.layerMasks.droppable;
			platform.layer = (int)GameManager.layerBits.droppable;
			flower.layer = (int)GameManager.layerBits.ignoreRaycast;
			ground.layer = (int)GameManager.layerBits.droppable;

		}
		else{
			flower.layer = (int)GameManager.layerBits.ignoreRaycast;
//			glow.layer = 1 << (int)GameManager.layerBits.flowerGlow;
			layerMask1 = 1 << (int)GameManager.layerBits.flowerGlow;
			//layerMask1 = (int)GameManager.layerMasks.flower;
			platform.layer = (int)GameManager.layerBits.ignoreRaycast;
			ground.layer = (int)GameManager.layerBits.ignoreRaycast;

		}


			
		hoverFlower flowerMethods = flower.GetComponent<hoverFlower> ();
		if (Physics.Raycast (transform.position, fwd, out hit, layerMask1)) {
			Debug.Log ("hit collider is " + hit.collider.name);
//			Debug.Log ("gameobject is " + hit.transform.gameObject.name);
			seenObj = hit.transform.GetComponent<IGazeable> ();
			
//			flDistance = Vector3.Distance (hit.point, flower.transform.position);
//			flDistance2 = Vector3.Distance (cursorEnd.transform.position, flower.transform.position);


			if (GameManager.pickedUp == false && flower.GetComponent<Rigidbody>().useGravity == false) {
				
				Material glowOrb = glow.GetComponent<Renderer> ().material;

				Vector3 glowSize = glowOriginalScale + new Vector3 (1f, 1f, 1f);
				LeanTween.scale (glow, glowSize, 1f);
				Utilities.setAlpha (glowOrb, .5f);


//				float distancePastGlow = 0f;

//				if (flDistance2 > 2.5f && flDistance2 < 2.3f && cursorReady == true) {
//					Debug.Log ("hover flower");
//
//					flowerMethods.onGazeEnter ();
//					Utilities.setAlpha (glowOrb, flDistance2*.66f - .33f);
//
//					distancePastGlow = 2f - flDistance2;
//					glowExpand = distancePastGlow / glowExpandDampen;
//
//					if(glow.transform.localScale.x < 45f)
//						glow.transform.localScale += new Vector3 (distancePastGlow, distancePastGlow, distancePastGlow);
//
//				} else if (flDistance2 < 2.5f & cursorReady == true) {
//					Debug.Log ("Pick up flower");
//					GameManager.onGaze = true;
//					flowerMethods.pickUpFlower ();
//					cursorReady = false;
//				} else {
//					flowerMethods.onGazeExit ();
//					cursorReady = true;
//					glow.transform.localScale = glowOriginalScale;
//					Utilities.setAlpha (glowOrb, flDistance2*.5f);
//				}
			} else { //simple code to drop flower
				bool down = Input.GetKeyDown (KeyCode.Space);
				bool leftClick = Input.GetMouseButton (0);

				if (down || leftClick) {
					Debug.Log ("Drop flower");
					flowerMethods.dropFlower ();
					cursorReady = false;
				}
			}

		}

	
	}
}
