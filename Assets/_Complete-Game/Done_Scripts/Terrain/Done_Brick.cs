using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Brick : MonoBehaviour {
	int i=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "bullet") {
			if (i == 2) {
				Destroy (transform.parent.gameObject);
			}
			Destroy (coll.gameObject);
			i++;
		}
	}
}
