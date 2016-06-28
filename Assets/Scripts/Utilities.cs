using UnityEngine;
using System.Collections;

public static class Utilities{

	// Use this for initialization

	public static void setAlpha(Material temp, float alphaValue){
		Debug.Log ("++Set Alpha");
		Color tempColor = temp.color;
		tempColor.a = alphaValue;
		temp.color = tempColor;
	}

	public static void addGravity(Rigidbody curr){
		curr.isKinematic = false;
		curr.useGravity = true;
	}


}
