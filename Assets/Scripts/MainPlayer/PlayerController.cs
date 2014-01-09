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
	void FixedUpdate () {
		base.FixedUpdate ();
		anim.SetBool ("OnGround",_onGround);
		anim.SetBool ("Falling", _falling);

		if (Random.Range (0, 1000) < 10)
			anim.SetTrigger ("Wink");

		_dir.x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed",Mathf.Abs(_dir.x));
		if (Input.GetButtonDown ("Jump") && _onGround) {
			jump ();
			anim.SetBool("Pushing",false);
			anim.SetTrigger("Jump");	
		}

		if (Input.GetButtonDown ("Fire1"))
			anim.SetTrigger ("Create");
	}

	void createWall(){
		Instantiate (prefab,_midFrontVector,Quaternion.identity);
	}

	void OnCollisionStay2D(Collision2D collision){
		if (_onGround) {
			foreach (ContactPoint2D contact in collision.contacts) {
				if (Vector2.Dot (contact.normal, _dir) < 0) {
					if (contact.collider.tag == "wall")
						anim.SetBool ("Pushing", true);
				} else
					anim.SetBool ("Pushing", false);
			}
	}
	}
}
