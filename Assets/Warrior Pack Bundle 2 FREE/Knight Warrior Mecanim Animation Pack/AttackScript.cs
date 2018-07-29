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

    float timeLeft = 0.8f;

    float attackingDistance = 3f;
    //The target player
    Transform playerTransform;
    GameObject player;
    //At what distance will the enemy walk towards the player?
    public float walkingDistance = 10.0f;
    //In what time will the enemy complete the journey between its position and the players position
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    PlayerBehaviour playerBehaviour;

    SpawnScript spawnScript;

    GameObject enemy;

    // Use this for initialization
    void Start(){
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        anim = GetComponent<Animator>();
        updateHealthBar();
        spawnScript = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnScript>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update(){
        //Look at the player
        Vector3 locationOfPlayer = playerTransform.position;
        //locationOfPlayer.y = locationOfPlayer.y - 3f; // this offset is to prevent the enemies from targetting your head.
        //// now they target a bit lower and stay on the floor
        Vector3 lookTarget = new Vector3(locationOfPlayer.x, this.transform.position.y, locationOfPlayer.z);
        transform.LookAt(lookTarget);
        //Calculate 2D distance to player
        float dX = transform.position.x - playerTransform.position.x;
        float dZ = transform.position.z - playerTransform.position.z;
        float distance = Mathf.Sqrt(dX*dX + dZ*dZ);

        if (distance <= attackingDistance && isMoving) { // person is within range of the attack. stop moving
            anim.SetBool("Moving", false);
            isMoving = false;
            isAttacking = true;
            anim.SetTrigger("Attack1Trigger");
        }

        if (isAttacking && distance >= attackingDistance) { // person is out of range of the attack. keep moving.
            anim.ResetTrigger("Attack1Trigger");
            isAttacking = false;
            timeLeft = 0.8f;
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

        if (isAttacking)
        {
            timeLeft -= Time.deltaTime;
        }

        if (isAttacking && timeLeft < 0)
        {
            playerBehaviour.takeDamage(10);
            timeLeft = 0.8f;
            if (playerBehaviour.getHealth() <= 0)
            {
                Debug.Log("DEAD");
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                
                /*foreach (enemy e in enemies)
                {
                    e.stopAnimating();
                }*/
                spawnScript.startStop();
            }
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == player)
        {
            //playerBehaviour.takeDamage(25);
        }
    }

    private Slider healthBar;

    void updateHealthBar(){
        healthBar = GameObject.Find("Slider").GetComponent<Slider>();
        //healthBar.value = health;
    }

    void takeDamage(int amount){
        health -=amount;
        
        updateHealthBar();
    }

    void die () {
        anim.SetBool("Dead", true);
    }

    public void stopAnimating()
    {
        anim.SetBool("Moving", false);
        anim.ResetTrigger("Attack1Trigger");
    }
}
