using UnityEngine;
using System.Collections;

public class CharacterActions : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {	
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 1000) < 10)
			anim.SetTrigger ("Wink");

		if (Input.GetButtonDown ("Fire"))
			anim.SetTrigger ("Create");
	}
}
