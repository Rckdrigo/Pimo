using UnityEngine;
using System.Collections;

public class Character2DPhysicsManager : MonoBehaviour {
	public float gravity;

	void Start(){
		foreach(DynamicCharacter2D i in FindObjectsOfType<DynamicCharacter2D>()){
			i.rigidbody2D.gravityScale = gravity;
		}
	}
}
