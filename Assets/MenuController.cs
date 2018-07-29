using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public NetworkManager networkManager;
    public InputField ipInputField;

    void Start() {
        networkManager = NetworkManager.singleton;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void startViewer() {
        networkManager.StartServer();
    }

    public void startWeapon() {
        networkManager.networkAddress = ipInputField.text;
        Debug.Log(ipInputField.text);
        networkManager.StartClient();
    }
}
