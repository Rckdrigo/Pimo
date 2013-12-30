using UnityEngine;
using System.Collections;

public class ShootingEnemyIA : Character2D {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		_dir = Vector2.right;
	}

	void followWithSight(){
		Debug.DrawLine (midFrontVector,player.transform.position);
		if (Mathf.Sign (player.transform.position.x - transform.position.x) != Mathf.Sign (_dir.x)) {
			_dir.x *= -1;
			_flipH();
		}
	}

	// Update is called once per frame
	void Update () {
		base.Update ();

		followWithSight ();
	}
}
