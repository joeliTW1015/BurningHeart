using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject bat;
    Vector3 spawnPos;
    float spawnTime;
    float tempTime;
    // Start is called before the first frame update
    void Start()
    {
        tempTime = 0;
        spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.playerScore > 15)
        {
            tempTime += Time.deltaTime;
            if(spawnTime == 0)
            {
                spawnTime = Random.Range(5, 15);
                tempTime = 0;
            }
            else if(tempTime >= spawnTime)
            {
                SpawnBat();
                spawnTime = Random.Range(5, 15);
                tempTime = 0;
            }
        }
    }

    void SpawnBat()
    {
        Debug.Log("Bat!!!");
        spawnPos = new Vector3(8f * PlayerMove.moveDirect, Random.Range(-4, 4), 0);
        Instantiate(bat, spawnPos, transform.rotation);
    }
}
