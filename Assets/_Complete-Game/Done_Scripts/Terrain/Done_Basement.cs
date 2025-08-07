using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Basement : MonoBehaviour {
	public GameObject gameOver;
 	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "bullet") {
			Destroy (transform.parent.gameObject);
			Instantiate (gameOver, new Vector3(Screen.width/1600,Screen.height/800,0), Quaternion.identity);
			Destroy (coll.gameObject);

		}
	}
}
