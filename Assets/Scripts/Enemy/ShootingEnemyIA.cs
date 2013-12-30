using UnityEngine;
using System.Collections;

public class ShootingEnemyIA : Character2D {

	public int nBullet;
	public float bulletDelay;
	public float sequenceDelay;

	public Transform prefab;

	private GameObject player;
	private bool isInRange;

	IEnumerator shootSequence(){
		for (int i = 0; i < nBullet; i++) {
			if(isInRange){
				shoot ();
				yield return new WaitForSeconds (bulletDelay);
			}
		}
		yield return new WaitForSeconds (sequenceDelay);
		StartCoroutine (shootSequence());
	}

	void shoot(){
		print ("Shoot");
		Instantiate (prefab,_midFrontVector,Quaternion.LookRotation(_dir));
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		_dir = Vector2.right;

		StartCoroutine (shootSequence ());
	}

	void followWithSight(){
		print (Mathf.Abs (player.transform.position.y - transform.position.y) );
		if (Mathf.Abs (player.transform.position.y - transform.position.y) < _height * 3.0f)
			isInRange = true;	
		else
			isInRange = false;

		if (Mathf.Sign (player.transform.position.x - transform.position.x) != Mathf.Sign (_dir.x)) {
			_dir.x *= -1;
			_flipH();
		}
	}

	// Update is called once per frame
	void Update () {
		base.Update ();
		followWithSight();
	}
}
