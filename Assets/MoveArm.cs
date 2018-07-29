using UnityEngine;
using System.Collections;

public class MoveArm : MonoBehaviour {
	//private Accelerometer accel;
	void Start(){
		/*accel = Input.acceleration;
         if(!acceleration.enabled){
             acceleration.enabled = true;
		 }*/
	}
    void Update(){
        transform.Translate(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z);
    }
}