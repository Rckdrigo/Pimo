using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

	GameObject player;
	GameObject falseCollider;

	// Use this for initialization
	void Start () {
		collider2D.enabled = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		
		/*falseCollider = new GameObject();
		falseCollider.name = "FalsePlatform";
		falseCollider.layer = LayerMask.NameToLayer("FalseScenario");
		falseCollider.transform.parent = transform;
		falseCollider.AddComponent<BoxCollider2D> ();
		falseCollider.GetComponent<BoxCollider2D> ().size = GetComponent<BoxCollider2D> ().size;
		falseCollider.GetComponent<BoxCollider2D> ().center = GetComponent<BoxCollider2D> ().center;
		falseCollider.transform.position = transform.position;*/
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y >= transform.position.y)
			collider2D.enabled = true;
		else 
			collider2D.enabled = false;
	}

}
