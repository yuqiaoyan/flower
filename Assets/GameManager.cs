using UnityEngine;
using System.Collections;

public static class GameManager
{
	public static Vector3 dropLocation = Vector3.zero;
	public static bool pickedUp = false;
	public static bool onGaze = false;


	public enum layerBits{
		ignoreRaycast = 2,
		flower = 8,
		droppable = 9,
		flowerGlow = 11
	}

	public enum layerMasks{
		ignoreRaycast = 1 << layerBits.ignoreRaycast,
		flower = 1 << layerBits.flower,
		droppable = 1 << layerBits.droppable
	}

	public enum scenes{
		protoBase,
		proto1Snap,
		proto2Input

	}

	public static scenes currScene;
			
			
}

