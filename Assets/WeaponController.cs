using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponController : NetworkBehaviour {
    private GameObject arm;
    private GameObject armOffset;

    // Use this for initialization
    void Start () {
        arm = GameObject.FindWithTag("Arm");
        armOffset = GameObject.FindWithTag("ArmCoordinateSpace");

        GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().setWeaponController(this.gameObject);
        
        if (isLocalPlayer) {
            if (!Input.gyro.enabled) Input.gyro.enabled = true;

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;

            Camera.main.enabled = false;
        }
        else {
            GameObject.FindWithTag("WeaponUI").SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) return;

        arm.transform.localRotation = Input.gyro.attitude;
    }

    public void Calibrate() {
        Quaternion deltaRotation = new Quaternion();
        deltaRotation.SetFromToRotation(Input.gyro.gravity, Vector3.down);

        armOffset.transform.rotation = deltaRotation;
    }
}