using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Done_Player2 : MonoBehaviour {

	public int direction = 1;

	public float bulletSpeed;
	public GameObject bullet;
	public Transform shootPoint;
	public Animator a;

	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			}
			gameObject.transform.Translate(new Vector2(0,0.01F));
			direction = 1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			}
			gameObject.transform.Translate(new Vector2(0,0.01F));
			direction = 2;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			}
			gameObject.transform.Translate(new Vector2(0,0.01F));
			direction = 3;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			}
			gameObject.transform.Translate(new Vector2(0,0.01F));
			direction = 4;
		}
		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			Fire ();
		}

	}
	public void Fire(){
		GameObject go = Instantiate (bullet, shootPoint.position, Quaternion.identity)as GameObject;

		switch(direction){
		    case 1:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, 1*bulletSpeed);break;
		    case 2:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, -1*bulletSpeed);break;
		    case 3:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (-1*bulletSpeed, 0);break;
		    case 4:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (1*bulletSpeed, 0);break;
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "bullet") {
			a.Play ("explode");
			Destroy (gameObject,0.25F);
			Destroy (coll.gameObject);
			GameObject.Find("life2").GetComponent<Text>().text="0";

		}
	}
}
