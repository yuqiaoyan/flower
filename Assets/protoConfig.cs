using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class protoConfig : MonoBehaviour {


	string currSceneName;

	void Awake(){
		currSceneName = SceneManager.GetActiveScene ().name;
		Debug.Log ("Scene name " + currSceneName);

		switch (currSceneName) {
			case "proto2-Input":
				GameManager.currScene = GameManager.scenes.proto2Input;
				break;
			case "proto1-Snap":
				GameManager.currScene = GameManager.scenes.proto1Snap;
				break;
		}
	}
		

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
