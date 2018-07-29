using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour {

    public GameObject enemy;
    GameObject player;
    PlayerBehaviour playerBehaviour;

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {

        // If the entering collider is an enemy...
        if (col.gameObject == enemy)
        {
            Debug.Log("Hit by enemy!");
 
            playerBehaviour.takeDamage(25);
        }
    }
}
