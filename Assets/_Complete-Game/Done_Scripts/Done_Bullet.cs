using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Bullet : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Destroy (gameObject, 2.5f);
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "bullet") {
			Destroy (gameObject);
			Destroy (coll.gameObject);

		}
	}
}
