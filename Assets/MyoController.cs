using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyoController : MonoBehaviour
{
    private GameObject arm;

    void Start()
    {
        arm = GameObject.FindWithTag("OffHand");
        //gotMessage("7, 90, 90");
    }

    void gotMessage(string dataString)
    {
        Debug.Log(dataString);
        string[] sarray = dataString.Split(',');
        arm.transform.eulerAngles = new Vector3(float.Parse(sarray[0]), float.Parse(sarray[1]), float.Parse(sarray[2]));
    }
}
