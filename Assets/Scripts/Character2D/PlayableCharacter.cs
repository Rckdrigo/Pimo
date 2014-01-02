using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayableCharacter : DynamicCharacter2D {

	public float _jumpSpeed;

	protected void jump(){
		print (_onGround);
		if (_onGround) {
			rigidbody2D.velocity = Vector2.up * _jumpSpeed * Time.deltaTime;
		}
	}
}
