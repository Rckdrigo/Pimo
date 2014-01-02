using UnityEngine;
using System.Collections;

public class ShootingEnemyIA : StaticCharacter2D {

	public int nBullet;
	public float bulletDelay;
	public float sequenceDelay;

	private GameObject player;
	private bool isInRange;
	private GameObject[] bulletPool;
	private int poolCount;
	private Animator anim;


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
		anim.SetTrigger ("Shoot");
	}

	void throwBullet(){
		//print ("BAM");
		BulletPoolManager.getBullet ();
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindWithTag ("Player");
		_dir = Vector2.right;

		StartCoroutine (shootSequence ());
	}

	void followWithSight(){
		if (Mathf.Sign (player.transform.position.x - transform.position.x) != Mathf.Sign (_dir.x)) {
			_dir.x *= -1;
			_flipH();
		}
	}

	// Update is called once per frame
	void Update () {
		base.Update ();

		followWithSight();
		if (Mathf.Abs (player.transform.position.y - transform.position.y) < _height*1.5f)
			isInRange = true;	
		else
			isInRange = false;
	}
}
