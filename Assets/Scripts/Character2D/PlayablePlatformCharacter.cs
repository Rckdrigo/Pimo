using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayableCharacter : DynamicCharacter2D {	
	[HideInInspector]
	protected bool _falling;

	public float _jumpSpeed;
	protected void jump(){
		rigidbody2D.velocity = Vector2.up * _jumpSpeed * 10 * Time.deltaTime;
	}

	protected void Update(){
		base.Update ();
		rigidbody2D.gravityScale = 0;
		rigidbody2D.velocity -= Vector2.up * 9.8f * Time.deltaTime;
		if (rigidbody2D.velocity.y < 0 && !_onGround)
				_falling = true;
		else 
				_falling = false;


		transform.Translate (_dir * _speed * Time.deltaTime);
	}
}
