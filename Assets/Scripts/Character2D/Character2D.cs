using UnityEngine;
using System.Collections;

#region REQUIERED_COMPONENTS
/*[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (Collider2D))]*/
#endregion
public abstract class Character2D : MonoBehaviour {
	#region PUBLIC_ATTRIBUTES
	public float _speed;
	public Vector2 _dir;

	#endregion

	#region INSIDE_INHERITED_MEMBERS
	protected float _width;
	protected float _height;
	protected bool _onGround;
	protected Vector2 _midFrontVector;

	/// <summary>
	/// Calculating all the attributes that are usefull for all kind of interaction
	/// Such as: width, height, onGround
	/// </summary>

	protected void Update () {
		resizeBoxCollider ();
		_midFrontVector = frontalVector ();
		_onGround = isOnGround ();
		_width =  renderer.bounds.size.x;
		_height =  renderer.bounds.size.y;

		_dir.Normalize ();
	}

	protected void _flipH(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x*-1,temp.y);
	}

	protected void _flipV(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x,temp.y*-1);
	}
	#endregion

	#region INTERNAL_PROCESS
	/// <summary>
	/// Resizes the box collider each frame
	/// </summary>
	private void resizeBoxCollider(){
		switch (collider2D.GetType ().ToString ()) {
		case "UnityEngine.BoxCollider2D":
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			Vector3 size = new Vector3(_width,_height);
			box.size = size;
			break;
		
		case "UnityEngine.CircleCollider2D":
			CircleCollider2D circle = GetComponent<CircleCollider2D>();
			circle.radius = _width>=_height?_width : _height;
			break;

		 
		}
	}

	/// <summary>
	/// Verify each frame if the character is over the ground.
	/// </summary>
	/// <returns><c>true</c>, if raycast detects collision under the sprite, <c>false</c> otherwise.</returns>
	private bool isOnGround(){
		if (Physics2D.Raycast (transform.position, -Vector2.up, _height*0.1f)) {
			return true;
		}
		return false;
	}

	private Vector2 frontalVector(){
		return new Vector2 (transform.position.x + _width/2 * _dir.x, transform.position.y + _height/2);
	}
	#endregion
}
