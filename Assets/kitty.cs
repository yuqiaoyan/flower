using UnityEngine;
using System.Collections;

public class kitty : MonoBehaviour {

	Animator animator;
	Rigidbody rb;
	public float speed;
	bool down = false;
	bool leftClick = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
		speed = 1;
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

			animator.SetBool ("Walk", true);
			rb.AddForce (new Vector3 (0, 0, speed));

			//animator.SetBool ("Jump", true);



		}
	
	}
}
