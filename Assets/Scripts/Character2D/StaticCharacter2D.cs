using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public abstract class StaticCharacter2D : Character2D {

	protected Vector2 _dir;
	protected void FixedUpdate(){
		_dir.Normalize ();
		
		_width =  renderer.bounds.size.x;
		_height =  renderer.bounds.size.y;
	}
}
