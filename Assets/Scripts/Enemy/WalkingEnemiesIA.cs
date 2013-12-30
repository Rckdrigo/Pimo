using UnityEngine;
using System.Collections;

public class WalkingEnemiesIA : Character2D {

	public enum TYPE{A,B}
	public TYPE type;
	private bool inEdge;

	private bool searchEdge(){
		Vector3 temp = new Vector3 (transform.position.x + _width/2 * _dir.x, 
		                            transform.position.y, transform.position.z);
		if (Physics2D.Raycast (temp, -Vector2.up,_height*0.1f)) 
			return false;
		return true;
	}

	private void searchFrontalCollision(){
		Collider2D[] results;
		foreach (Collider2D collider in Physics2D.OverlapPointAll(_midFrontVector)) {
			if (collider.gameObject != gameObject) {
				print(collider.gameObject.tag != gameObject.tag);
				if (collider.gameObject.layer != gameObject.layer) {
					//print (collider.name);
					_dir.x *= -1;
					_flipH ();
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		inEdge = false;
		_dir.x = 1;
	}

	void Update(){
		base.Update ();

		//Searching for platform edge
		switch (type) {
		case TYPE.A:
			if (_onGround) {
				if (!inEdge)
						transform.Translate (Vector3.right * Time.deltaTime * _speed * _dir.x, Space.World);

				else {
						_dir.x *= -1;
						_flipH();
				}
			}
			break;
		
		case TYPE.B:
				transform.Translate (Vector3.right * Time.deltaTime * _speed * _dir.x, Space.World);
				break;
		}



	}

	void LateUpdate () {
		inEdge = searchEdge ();
		searchFrontalCollision ();
	}

}
