using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Done_Enemy : MonoBehaviour {
	public float patrolTime;
	public float patrolCd;
	public float attackTime;
	public float attackCd;
	public float moveSpeed;
	public float bulletSpeed;
	public int life;

	public bool isred;
	public GameObject[] props;

	public int direction = 1;

	public GameObject bullet;
	public Transform shootPoint;
	public Animator a;

	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		patrolTime += Time.deltaTime;
		attackTime +=Time.deltaTime;
		if (patrolTime >= patrolCd) {
			Move ();
			patrolTime = 0;
		}
		if (attackTime >= attackCd) {
			Fire ();
			attackTime = 0;
		}
	}
	public void Fire(){
		GameObject go = Instantiate (bullet, shootPoint.position, Quaternion.identity)as GameObject;
		//bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.Translate (new Vector3 (0,1,0));
		switch(direction){
		    case 1:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, 1*bulletSpeed);break;
		    case 2:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, -1*bulletSpeed);break;
		    case 3:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (-1*bulletSpeed, 0);break;
		    case 4:go.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (1*bulletSpeed, 0);break;
		}
	}
	public void Move(){
		int moveNum = Random.Range (0, 5);
		if (moveNum == 0) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			}
			gameObject.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, 1 * moveSpeed * Time.deltaTime);
			direction = 1;
		}
		if (moveNum == 1 ||moveNum == 4 ) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			}
			gameObject.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, -1 * moveSpeed * Time.deltaTime);
			direction = 2;
		}
		if (moveNum == 2) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			}
			gameObject.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (-1 * moveSpeed * Time.deltaTime, 0);
			direction = 3;
		}
		if (moveNum == 3) {
			switch (direction) {
			    case 1:gameObject.transform.Rotate(new Vector3(0,0,270));break;
			    case 2:gameObject.transform.Rotate(new Vector3(0,0,90));break;
			    case 3:gameObject.transform.Rotate(new Vector3(0,0,180));break;
			    case 4:gameObject.transform.Rotate(new Vector3(0,0,0));break;
			}
			gameObject.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (1 * moveSpeed * Time.deltaTime, 0);
			direction = 4;
		}
	}

	private bool cansub=true;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "bullet" ) {
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.name == "Done_bullet1(Clone)") {
				life--;
				if (life == 0) {
					if (isred) {
						Instantiate (props[0], gameObject.transform.position, Quaternion.identity);
					}
					a.Play ("explode");
					Destroy (gameObject, 0.25F);
					if (cansub) {
						GameObject.Find ("Text").GetComponent<Done_EnemyUI> ().number--;
						int n = GameObject.Find ("Text").GetComponent<Done_EnemyUI> ().number;
						GameObject.Find ("Text").GetComponent<Text> ().text = "" + n;
						cansub = false;
					}
				}
			}
			Destroy (coll.gameObject);

		}
	}
}
