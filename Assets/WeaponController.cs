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

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Portrait;

        if (!Input.gyro.enabled) Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) return;

        this.gameObject.transform.eulerAngles = new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f);

        arm.transform.rotation = Input.gyro.attitude;
        //Quaternion targetRotation = GyroToUnity(Input.gyro.attitude);
        //arm.transform.rotation = targetRotation;
    }

    public void Calibrate()
    {
        Quaternion deltaRotation = new Quaternion();
        deltaRotation.SetFromToRotation(Input.gyro.gravity, Vector3.down);

        armOffset.transform.rotation = deltaRotation;
    }

    //private static Quaternion GyroToUnity(Quaternion q) {
    //    return q;
    //    //return new Quaternion(q.x, q.y, -q.z, -q.w);
    //}
}