using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_SpawnEnemy : MonoBehaviour {
	
	public GameObject []enemys;
	public bool canCreate;

	public float spawnTime;
	public float spawnCd;
	public  int enemyNumber=0;

	void Update () {

		spawnTime +=Time.deltaTime;

		if (canCreate) {
			
			//a.Play ("spawn");
			switch (Random.Range (0, 4)) {
			case 0:
				Instantiate (enemys [0], gameObject.transform.position, Quaternion.identity);
				break;
			case 1:
				Instantiate (enemys [1], gameObject.transform.position, Quaternion.identity);
				break;
			case 2:
				Instantiate (enemys [2], gameObject.transform.position, Quaternion.identity);
				break;
			case 3:
				Instantiate (enemys [Random.Range(0,6)], gameObject.transform.position, Quaternion.identity);
				break;
			}
			canCreate = false;
			enemyNumber++;
		}

		if (spawnTime >= spawnCd && enemyNumber<=5) {
			canCreate = true;
			spawnTime = 0;
		}
	}
}
