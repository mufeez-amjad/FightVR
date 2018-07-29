using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randEnemy;

    GameObject knight;

    // Use this for initialization
    void Start()
    {
        //knight = GameObject.FindGameObjectWithTag("Knight Warrior");
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

        

    }

    void stopAnimation()
    {
        foreach (GameObject g in enemies)
        {
            if (g == knight) {
            }
        }
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, enemies.Length);
            float minDistance = 30.0f;
            float maxDistance = 30.0f;
            float distance = Random.Range(minDistance, maxDistance);
            float angle = Random.Range(-Mathf.PI, Mathf.PI);

            Vector3 spawnPosition = this.transform.position;
            spawnPosition += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -spawnValues.x, spawnValues.x);
            spawnPosition.y = spawnValues.y;
            spawnPosition.z = Mathf.Clamp(spawnPosition.z, -spawnValues.z, spawnValues.z);

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}