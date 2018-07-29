using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("hi");
		OnTriggerEnter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void  OnTriggerEnter(){
		Debug.Log("HIT DETECTED");
	}
}
