using UnityEngine;
using System.Collections;

public class PlayerLocomotion : PlayableCharacter {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		if (Input.GetButtonDown ("Jump") && _onGround)
			jump ();

		_dir.x = Input.GetAxis ("Horizontal");
	}
}
