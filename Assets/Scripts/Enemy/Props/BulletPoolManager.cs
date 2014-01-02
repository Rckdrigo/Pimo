using UnityEngine;
using System.Collections;

public class BulletPoolManager:MonoBehaviour{
	static int nBullets;
	static int index;
	static GameObject[] bullet;

	void Start(){
		bullet = GameObject.FindGameObjectsWithTag ("bullet");
		nBullets = bullet.Length;
		index = 0;
	}

	public static GameObject getBullet(){
		int temp;
		if (index < nBullets) {
			temp = index;
			index++;
		} else {
			index = 0;
			temp = index;
		}
		
		//bullet[temp].GetComponent<BulletBehaviour>().active = true;
		return bullet[temp];
	}
}
