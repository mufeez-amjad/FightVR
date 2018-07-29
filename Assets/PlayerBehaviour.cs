using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour {
    public Image healthFilter;

    Camera mainCamera;


    private int maxHealth = 100;
    private int health = 100;
	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.eulerAngles = new Vector3(0f, mainCamera.transform.eulerAngles.y, 0f);

		if (Input.GetKey(KeyCode.W) || Input.GetMouseButton(0)){
            float facing = mainCamera.transform.eulerAngles.y;

            gameObject.transform.Translate(0f, 0f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.A)){ // TEMPORARY: made teleport   
            gameObject.transform.position += gameObject.transform.forward * 10;
        }
        if (Input.GetKeyDown(KeyCode.J)){ // TEMPORARY: made damage self   
            takeDamage(20);
        }
    }
    void OnCollisionEnter(Collision col){
        Debug.Log("Collided with player");
    }

    private YieldInstruction fadeInstruction = new YieldInstruction();
    float fadeTime = 2.0f;
    IEnumerator FadeOut(Image image){
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime){
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }


    private void checkFilter(){
        Debug.Log(health);
        if(health <= 10){
           healthFilter.color = new Color(255, 0, 0, 0.9f);
        }else if(health <= 20){
           healthFilter.color = new Color(255, 0, 0, 0.6f);
        }else if(health <= 40){
           healthFilter.color = new Color(255, 0, 0, 0.35f);
        }else if(health <= 60){
           healthFilter.color = new Color(255, 0, 0, 0.1f);
        }else if(health <= 80){
           healthFilter.color = new Color(255, 0, 0, 0.05f);
        }
        StartCoroutine(FadeOut(healthFilter));
    }

    public void takeDamage(int amount){
        health -=amount;
        checkFilter();
    }
}
