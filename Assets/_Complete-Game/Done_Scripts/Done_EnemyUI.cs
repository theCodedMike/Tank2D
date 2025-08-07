using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Done_EnemyUI : MonoBehaviour {
	public int number;

	void Start () {
		GameObject.Find ("Text").GetComponent<Text> ().text =""+ number;
	}
}
