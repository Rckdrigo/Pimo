using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayableCharacter : DynamicCharacter2D {	
	[HideInInspector]
	public bool falling;

	public float _jumpSpeed;

	protected void jump(){
		rigidbody2D.velocity = Vector2.up * _jumpSpeed * 10 * Time.deltaTime;
	}

	protected void Update(){
		base.Update ();	
		if (rigidbody2D.velocity.y < 0 && !_onGround)
			falling = true;

		transform.Translate (_dir * _speed * Time.deltaTime);
	}
}
