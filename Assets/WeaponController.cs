using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponController : NetworkBehaviour {
    private GameObject arm;

	// Use this for initialization
	void Start () {
        arm = GameObject.FindWithTag("Arm");

        GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().setWeaponController(this.gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Portrait;

        if (!Input.gyro.enabled) Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) return;

        this.gameObject.transform.eulerAngles = new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f);

        Quaternion targetRotation = GyroToUnity(Input.gyro.attitude);
        Debug.Log("gyro.attitude: " + targetRotation.eulerAngles.ToString("F6"));
        Debug.Log("gyro.gravity:  " + Input.gyro.gravity.ToString("F6"));
        Debug.Log("acceleration:  " + Input.acceleration.ToString("F6"));
        arm.transform.rotation = targetRotation;
    }

    private static Quaternion GyroToUnity(Quaternion q) {
        return q;
        //return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}