using UnityEngine;
using System.Collections;

public class PlayerLocomotion : PlayableCharacter {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		if (Random.Range (0, 1000) < 10)
			anim.SetTrigger ("Wink");

		anim.SetBool ("Falling", _falling);

		if (Input.GetButtonDown ("Jump") && _onGround) {
			jump ();
			anim.SetTrigger("Jump");	
		}

		_dir.x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed",Mathf.Abs(_dir.x));
	}
}
