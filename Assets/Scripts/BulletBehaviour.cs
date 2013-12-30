using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public Vector2 dir;
	public float speed;

	// Update is called once per frame
	void Update () {
		if(renderer.enabled)
			transform.Translate (dir * Time.deltaTime * speed);

		if (Camera.main.WorldToScreenPoint(transform.position).x < 0 || Camera.main.WorldToScreenPoint(transform.position).x > Screen.width) {
			transform.position = transform.parent.position;
			renderer.enabled = false;
		}
	}
}
