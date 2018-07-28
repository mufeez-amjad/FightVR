using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W)){

            gameObject.transform.Translate(0f, 1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            gameObject.transform.Translate(0f, -1f, 0f);
        }
    }
}
