using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour {

    private Animator anim;
    public float health = 100;

    int maxHealth = 100;
    bool isDead = false;
    bool isMoving = false;
    bool isAttacking = false;

    float attackingDistance = 2.5f;
    //The target player
    public Transform player;
    //At what distance will the enemy walk towards the player?
    public float walkingDistance = 10.0f;
    //In what time will the enemy complete the journey between its position and the players position
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    // Use this for initialization
    void Start(){
        anim = GetComponent<Animator>();
        updateHealthBar();
	}

    // Update is called once per frame
    void Update(){
        //Look at the player
        Vector3 locationOfPlayer = player.position;
        locationOfPlayer.y = locationOfPlayer.y - (float)1.2; // this offset is to prevent the enemies from targetting your head.
        // now they target a bit lower and stay on the floor
        transform.LookAt(locationOfPlayer);
        //Calculate distance between player
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackingDistance && isMoving) { // person is within range of the attack. stop moving
            anim.SetBool("Moving", false);
            isMoving = false;
            isAttacking = true;
            anim.SetTrigger("Attack1Trigger");
        }

        if (isAttacking && distance >= attackingDistance) { // person is out of range of the attack. keep moving.
            anim.ResetTrigger("Attack1Trigger");
            isAttacking = false;
        }

        //If the distance is smaller than the walkingDistance
        //condition:distance < walkingDistance && distance >= attackingDistance + 1f
        else if (distance >= attackingDistance + 1f) {
            //Move the enemy towards the player with smoothdamp
            //transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
            if (!isMoving){
                anim.SetBool("Moving", true);
                isMoving = true;
            }
        }
        
    }

    private Slider healthBar;

    void updateHealthBar(){
        healthBar = GameObject.Find("Slider").GetComponent<Slider>();
        healthBar.value = health;
    }

    void takeDamage(int amount){
        health -=amount;
        updateHealthBar();
    }

    void die () {
        anim.SetBool("Dead", true);
    }
}
