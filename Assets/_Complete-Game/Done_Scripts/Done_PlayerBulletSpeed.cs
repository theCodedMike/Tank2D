using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_PlayerBulletSpeed : MonoBehaviour {
	public float speed;

	void Update () {
		Destroy (gameObject, 5f);
	}
	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Player") {
			Destroy (gameObject);
			c.gameObject.GetComponent<Done_Player1> ().bulletSpeed = 1f*speed;
		}
		if (c.gameObject.tag == "Player2") {
			Destroy (gameObject);
			c.gameObject.GetComponent<Done_Player2> ().bulletSpeed = 1f*speed;
		}
	}
}
