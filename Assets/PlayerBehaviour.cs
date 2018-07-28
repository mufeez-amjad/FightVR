using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    Camera mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.eulerAngles = new Vector3(0f, mainCamera.transform.eulerAngles.y, 0f);

		if (Input.GetKey(KeyCode.W) || Input.GetMouseButton(0)){
            float facing = mainCamera.transform.eulerAngles.y;

            gameObject.transform.Translate(0f, 0f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.A)){ // TEMPORARY: made teleport
            gameObject.transform.position += gameObject.transform.forward * 10;
        }
    }
}
