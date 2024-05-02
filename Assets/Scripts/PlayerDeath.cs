using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject spawnLine, partical, gameManager, aP;
    Animator animator;
    static public bool isdead;

    private void Start() {
        aP = GameObject.Find("AudioPlayer");
        isdead = false;
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Die")
        {
            Break();
        }
    }

    public void Break()
    {
        aP.GetComponent<PlayAudio>().Broken();
        aP.GetComponent<PlayAudio>().StopBurning();
        isdead = true;
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity =  new Vector2(0, 0);
        spawnLine.SetActive(false);
        partical.SetActive(false);
        spawnLine.GetComponent<Spawner>().enabled = false;
        animator.SetBool("breakAnim", true);
        GetComponent<PlayerMove>().hintText.text = "";
        GetComponent<PlayerMove>().countText.text = "";
    }

    public void Extinguished()
    {
        aP.GetComponent<PlayAudio>().Extinguish();
        aP.GetComponent<PlayAudio>().StopBurning();
        isdead = true;
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity =  new Vector2(0, 0);
        spawnLine.SetActive(false);
        partical.SetActive(false);
        spawnLine.GetComponent<Spawner>().enabled = false;
        animator.SetBool("extinguishAnim", true);
        GetComponent<PlayerMove>().hintText.text = "";
        GetComponent<PlayerMove>().countText.text = "";
    }

     public void GameOver()
    {
        aP.GetComponent<PlayAudio>().GameOver();
        gameManager.GetComponent<GameManager>().EndGamePanel();
        GetComponent<Renderer>().enabled = false;
    }
}

