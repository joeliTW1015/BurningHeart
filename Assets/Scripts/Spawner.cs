using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    float tempTime;
    public int spawnIndex;
    public List<GameObject> pipes;
    Vector3 spawnPos;

    // Update is called once per frame
    void Start() 
    {
       spawnPos = GetComponent<Transform>().position; 
       tempTime = 0;
    }

    void Update() 
    {
        if(PlayerMove.moveDirect == 1f)
        {
            transform.position = new Vector3(10, 0, 0);
        }
        else
        {
            transform.position = new Vector3(-10, 0, 0);
        }

        tempTime += Time.deltaTime;
        if(tempTime > spawnTime)
        {
            tempTime = 0f;
            SpawnPipes();
        }

    }
   

    void SpawnPipes()
    {
        spawnIndex = Random.Range(0, pipes.Count);
        spawnPos = GetComponent<Transform>().position;
        if(spawnIndex <= 4)
            spawnPos += new Vector3(0, Random.Range(-3f, 3f), 0);
        else
            spawnPos += new Vector3(0, Random.Range(-1.3f, 1.3f), 0);

        Instantiate(pipes[spawnIndex],spawnPos,transform.rotation);
    }
}
