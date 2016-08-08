using UnityEngine;
using System.Collections;

public class growGlow : MonoBehaviour {

	private Vector3 glowOriginalScale;

	// Use this for initialization
	void Start () {
		glowOriginalScale = this.transform.localScale;
	
	}
	
	// Update is called once per frame
	void Update () {
//		LeanTween.scale (this.gameObject, glowOriginalScale + new Vector3 (1f, 1f, 1f), 2f);
	
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("++ Trigger Enter glowOrb");
		LeanTween.scale (this.gameObject, glowOriginalScale + new Vector3 (.5f, .5f, .5f), 2f);
	}
}
