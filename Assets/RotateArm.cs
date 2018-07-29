using UnityEngine;

public class RotateArm : MonoBehaviour {
    private Gyroscope gyro;
    void Start(){
        gyro = Input.gyro;
         if(!gyro.enabled){
             gyro.enabled = true;
         }
    }

    void Update(){
       gameObject.transform.rotation  = gyro.attitude;
    }
}