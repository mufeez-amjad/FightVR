using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    Animator anim;
    int health = 100;
    bool isDead = false;
    bool isMoving = false;

    //The target player
    public Transform player;
    //At what distance will the enemy walk towards the player?
    public float walkingDistance = 10.0f;
    //In what time will the enemy complete the journey between its position and the players position
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 50;
        }

        if (health <= 0 && !isDead)
        {
            die();
            isDead = true;
        }

        //Look at the player
        transform.LookAt(player);
        //Calculate distance between player
        float distance = Vector3.Distance(transform.position, player.position);
        
        //If the distance is smaller than the walkingDistance
        if (distance < walkingDistance && distance >= 3.0f)
        {
            //Move the enemy towards the player with smoothdamp
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
            if (!isMoving)
            {
                //anim.SetBool("Moving", true);
                isMoving = true;
            }
        }
        if (distance == 3.0f)
        {
            anim.SetBool("Moving", false);
        }
    }

    void die () {
        anim.SetBool("Dead", true);
    }
}
