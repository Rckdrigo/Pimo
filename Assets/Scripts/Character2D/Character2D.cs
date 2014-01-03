using UnityEngine;
using System.Collections;

#region REQUIERED_COMPONENTS
#endregion
public abstract class Character2D : MonoBehaviour {

	#region INSIDE_INHERITED_MEMBERS
	protected float _width;
	protected float _height;
	protected bool _onGround;
	protected Vector2 _midFrontVector;
	protected bool facingRight = true;
	
	protected void _flipH(){
		facingRight = !facingRight;
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x*-1,temp.y);
	}

	protected void _flipV(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x,temp.y*-1);
	}
	
	protected void Update (){
	}
	#endregion 
	#region INTERNAL_PROCESS
	/// <summary>
	/// Resizes the box collider each frame
	/// </summary>
	protected void _resizeBoxCollider(Vector2 colliderOffset,Vector2 colliderScale){
		switch (collider2D.GetType ().ToString ()) {
		case "UnityEngine.BoxCollider2D":
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			Vector2 size = new Vector2(_width * colliderScale.x,_height * colliderScale.y);
			box.size = size;
			box.center = new Vector2(0 + colliderOffset.x,_height/2 + colliderOffset.y);
			break;
		
		case "UnityEngine.CircleCollider2D":
			CircleCollider2D circle = GetComponent<CircleCollider2D>();
			circle.radius = _width>=_height?_width : _height;
			break;
		
		default:
			break;
		}

	}
	#endregion
}
