using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Collider2D))]
public abstract class DynamicCharacter2D : Character2D {
	#region PUBLIC_ATTRIBUTES
	public float _speed;
	public LayerMask _groundLayer;
	#endregion

	protected Vector2 _dir;

	protected void Update(){	
		_dir.Normalize ();

		if(_dir.x > 0 && !facingRight)
			_flipH ();
		else if(_dir.x < 0 && facingRight)
			_flipH ();

		_resizeBoxCollider ();
		_midFrontVector = frontalVector ();
		_onGround = isOnGround ();
		_width =  renderer.bounds.size.x;
		_height =  renderer.bounds.size.y;
		rigidbody2D.fixedAngle = true;
	}

	private Vector2 frontalVector(){
		return new Vector2 (transform.position.x + _width/2 * _dir.x, transform.position.y + _height/2);
	}
		
	/// <summary>
	/// Verify each frame if the character is over the ground.
	/// </summary>
	/// <returns><c>true</c>, if raycast detects collision under the sprite, <c>false</c> otherwise.</returns>
	private bool isOnGround(){
		Collider2D ground = Physics2D.OverlapCircle (transform.position, _height * 0.1f, _groundLayer);
		if(ground != null)
			return true;
		return false;
	}

}
