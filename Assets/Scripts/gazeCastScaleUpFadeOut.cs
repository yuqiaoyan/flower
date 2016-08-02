using UnityEngine;
using System.Collections;

public class gazeCastScaleUpFadeOut : MonoBehaviour {

	public Camera headCamera;
	public Transform cursorLoc;
	public IGazeable seenObj, currObj = null;
	public int layerMask1;
	public bool cursorReady = true;
	public float glowExpandDampen = 10f, flDistance;


	private GameObject platform, flower, glow;
	private float glowExpand = 0f;
	private Vector3 glowOriginalScale;







	// Use this for initialization
	void Start () {
		platform = GameObject.FindGameObjectWithTag ("platform");
		flower = GameObject.Find("Flower");
		glow = GameObject.Find ("flowerGlow");

		glowOriginalScale = glow.transform.localScale;

	
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
			
		hoverFlower flowerMethods = flower.GetComponent<hoverFlower> ();
		if (Physics.Raycast (transform.position, fwd, out hit, layerMask1)) {
			seenObj = hit.transform.GetComponent<IGazeable> ();
			
			flDistance = Vector3.Distance (hit.point, flower.transform.position);


			if (GameManager.pickedUp == false && flower.GetComponent<Rigidbody>().useGravity == false) {
				
				Material glowOrb = glow.GetComponent<Renderer> ().material;

				float distancePastGlow = 0f;

				if (flDistance > 0.50f && flDistance < 2f && cursorReady == true) {
					Debug.Log ("hover flower");

					flowerMethods.onGazeEnter ();
					Utilities.setAlpha (glowOrb, flDistance*.66f - .33f);

					distancePastGlow = 2f - flDistance;
					glowExpand = distancePastGlow / glowExpandDampen;

					if(glow.transform.localScale.x < 45f)
						glow.transform.localScale += new Vector3 (distancePastGlow, distancePastGlow, distancePastGlow);

				} else if (flDistance < 0.50f && cursorReady == true) {
					Debug.Log ("Pick up flower");
					GameManager.onGaze = true;
					flowerMethods.pickUpFlower ();
					cursorReady = false;
				} else {
					flowerMethods.onGazeExit ();
					cursorReady = true;
					glow.transform.localScale = glowOriginalScale;
					Utilities.setAlpha (glowOrb, flDistance*.5f);
				}
			} else { //simple code to drop flower
				bool down = Input.GetKeyDown (KeyCode.Space);
				bool leftClick = Input.GetMouseButton (0);

				if (down || leftClick) {
					flowerMethods.dropFlower ();
					cursorReady = false;
				}
			}

		}

	
	}
}
