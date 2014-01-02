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
	
	protected void _flipH(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x*-1,temp.y);
	}

	protected void _flipV(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x,temp.y*-1);
	}
	
	protected void Update (){
		print (_height);
	}
	#endregion 
	
	#region INTERNAL_PROCESS
	/// <summary>
	/// Resizes the box collider each frame
	/// </summary>
	protected void _resizeBoxCollider(){
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
		
		default:
			break;
		}

	}
	#endregion
}
