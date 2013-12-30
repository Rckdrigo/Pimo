using UnityEngine;
using System.Collections;

public class ShootingEnemyIA : Character2D {

	public int nBullet;
	public float bulletDelay;
	public float sequenceDelay;

	public Transform prefab;

	private GameObject player;
	private bool isInRange;
	private GameObject[] bulletPool;
	private int poolCount;

	IEnumerator shootSequence(){
		for (int i = 0; i < nBullet; i++) {
			if (poolCount >= bulletPool.Length)
				poolCount = 0;


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
		bulletPool [poolCount].transform.position = _midFrontVector;
		bulletPool [poolCount].renderer.enabled = true;
		bulletPool [poolCount].GetComponent<BulletBehaviour> ().dir = _dir;
		print (poolCount);

		poolCount++;
	}

	// Use this for initialization
	void Start () {
		bulletPool = GameObject.FindGameObjectsWithTag ("bullet");
		print (bulletPool.Length);
		poolCount = 0;

		player = GameObject.FindGameObjectWithTag ("Player");
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

		if (Mathf.Abs (player.transform.position.y - transform.position.y) < _height * 2.5f)
			isInRange = true;	
		else
			isInRange = false;
	}
}
