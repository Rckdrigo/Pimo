using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public Vector2 dir;
	public float speed;

	[HideInInspector]
	public bool active;

	// Update is called once per frame
	void Update () {
		renderer.enabled = active;

		if(active)
			transform.Translate (dir * Time.deltaTime * speed);

		if (Camera.main.WorldToScreenPoint(transform.position).x < 0 || Camera.main.WorldToScreenPoint(transform.position).x > Screen.width) {
			transform.position = transform.parent.position;
			active = false;
		}
	}
}
