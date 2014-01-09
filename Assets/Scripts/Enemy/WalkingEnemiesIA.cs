using UnityEngine;
using System.Collections;

public class WalkingEnemiesIA : DynamicCharacter2D {

	public enum TYPE{A,B}
	public TYPE type;
	private bool onEdge;

	private bool searchEdge(){
		if (_onGround) {
			Vector3 temp = new Vector3 (transform.position.x + _width / 2 * _dir.x, 
                    transform.position.y, transform.position.z);
			Collider2D ground = Physics2D.OverlapCircle (temp, _height * 0.1f, _groundLayer);
			if(ground != null)
				return false;
			return true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		onEdge = false;
		_dir.x = 1;
	}

	void FixedUpdate(){
		base.FixedUpdate ();

		//Searching for platform edge
		switch (type) {
		case TYPE.A:
			if (_onGround) {
				if (!onEdge)
						transform.Translate (Vector3.right * Time.deltaTime * _speed * _dir.x, Space.World);
				else 
						_dir.x *= -1;

			}
			break;
		
		case TYPE.B:
			transform.Translate (Vector3.right * Time.deltaTime * _speed * _dir.x, Space.World);
		
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		foreach (ContactPoint2D contact in collision.contacts) {
			if(Vector2.Dot(contact.normal, _dir) < 0){
				_dir.x *= -1;
			}
		}
	}

	void LateUpdate () {
		onEdge = searchEdge ();
		//searchFrontalCollision ();
	}

}
