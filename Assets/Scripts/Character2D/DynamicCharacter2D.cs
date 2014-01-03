using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Collider2D))]
[ExecuteInEditMode()]
public abstract class DynamicCharacter2D : Character2D {
	#region PUBLIC_ATTRIBUTES
	public float _speed;
	public LayerMask _groundLayer;
	
	public Vector2 colliderScale;
	public Vector2 colliderOffset;
	#endregion


	protected Vector2 _dir;

	protected void Update(){	
		_dir.Normalize ();

		if(_dir.x > 0 && !facingRight)
			_flipH ();
		else if(_dir.x < 0 && facingRight)
			_flipH ();

		_resizeBoxCollider (colliderOffset,colliderScale);
		_midFrontVector = frontalVector ();
		_onGround = isOnGround ();
		_width =  renderer.bounds.size.x;
		_height =  renderer.bounds.size.y;
		rigidbody2D.fixedAngle = true;
	}

	private Vector2 frontalVector(){
		return new Vector2 (transform.position.x + _width/2 * (facingRight ? 1 : -1), transform.position.y + _height/2);
	}
		
	/// <summary>
	/// Verify each frame if the character is over the ground.
	/// </summary>
	/// <returns><c>true</c>, if raycast detects collision under the sprite, <c>false</c> otherwise.</returns>
	private bool isOnGround(){
		Collider2D ground = Physics2D.OverlapCircle (transform.position, _width * 0.2f, _groundLayer);
		if(ground != null)
			return true;
		return false;
	}

}
