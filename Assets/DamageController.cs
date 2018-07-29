using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

	private GameObject sword;
	// Update is called once per frame
	void Update () {
		sword = GameObject.FindGameObjectWithTag("Sword");
		float speed = sword.GetComponent<Rigidbody>().velocity.magnitude;


		if (speed > 2){
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

			foreach (GameObject g in enemies){
				//g.die();
				Destroy(g);
			}
		}
	}
}