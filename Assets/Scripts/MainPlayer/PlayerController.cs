using UnityEngine;
using System.Collections;

public class PlayerController : PlayableCharacter {

	public Transform prefab;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		anim.SetBool ("Falling", _falling);

		if (Random.Range (0, 1000) < 10)
			anim.SetTrigger ("Wink");

		_dir.x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed",Mathf.Abs(_dir.x));
		if (Input.GetButtonDown ("Jump") && _onGround) {
			jump ();
			anim.SetTrigger("Jump");	
		}
		if (Input.GetButtonDown ("Fire1"))
			anim.SetTrigger ("Create");
	}

	void createWall(){
		print ("Creando paredes");
		Instantiate (prefab,_midFrontVector,Quaternion.identity);
	}
}
