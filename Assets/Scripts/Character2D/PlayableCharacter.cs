using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayableCharacter : DynamicCharacter2D {	
	
	public float _jumpSpeed;

	protected bool _falling;
	protected bool _jumping;
	protected void jump(){
		_jumping = true;
		rigidbody2D.velocity = Vector2.up * _jumpSpeed * 10 * Time.deltaTime;
	}

	protected void FixedUpdate(){
		base.FixedUpdate ();

		if (_jumping && _onGround)
			_jumping = false;

		if (rigidbody2D.velocity.y < 0 && !_onGround) {
			_falling = true;
			_jumping = false;
		}
		else 
			_falling = false;


		transform.Translate (_dir * _speed * Time.deltaTime);
	}
}
