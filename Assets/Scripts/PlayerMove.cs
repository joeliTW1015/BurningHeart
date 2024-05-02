using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Text scoreText, countText, hintText;
    Rigidbody2D rb;
    static public float graDirect;
    static public float moveDirect;
    public float jumpForce = 250f, switchTime = 0f, tempTime = 0f; 
    public Vector2 playerMovement;
    public bool jump = false;
    bool changeGrav;
    static public int playerScore, HighestScore;
    GameObject aP;
    // Start is called before the first frame update
    void Start()
    {
        aP = GameObject.Find("AudioPlayer");
        rb = GetComponent<Rigidbody2D>();   
        rb.gravityScale = 1.5f;
        graDirect = 1.5f;
        moveDirect = 1f;
        playerScore = 0;
        HighestScore = PlayerPrefs.GetInt("HighestScore", 0);
        aP.GetComponent<PlayAudio>().Burning();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            jump = true;
        }

        if(tempTime == 0f)
        {
            switchTime = Random.Range(15f, 30f);
            tempTime += Time.deltaTime;
            if(Random.Range(0f, 1f) > 0.5f)
            {
                changeGrav = true;
            }
        }
        else if(tempTime >= switchTime)
        {
            tempTime = 0f;
            if(changeGrav)
            {
                ReverseGravity();
            }
            else
            {
                ReverseMove();
            }
        }
        else
        {
            tempTime += Time.deltaTime;
        }

        if(switchTime - tempTime < 4.9f)
        {
            countText.text = (switchTime - tempTime + 1).ToString("0");
            if(changeGrav)
            {
                hintText.text = "GRAVITY DIRECTION WILL CHANGE!";
            }
            else
            {
                hintText.text = "MOVING DIRECTION WILL CHANGE!";
            }
        }
        else
        {
            hintText.text = " ";
            countText.text = " ";
        }
    }

    private void FixedUpdate() 
    {
        if(jump)
        {
            aP.GetComponent<PlayAudio>().HeartBeat();
            playerMovement = new Vector2(0f, jumpForce * graDirect * Time.deltaTime);
            rb.velocity = playerMovement;
            jump = false;
        }

        rb.gravityScale = graDirect;
    }

    void ReverseGravity()
    {
        aP.GetComponent<PlayAudio>().Beeper();
        graDirect *= -1f;
        Debug.Log("reverseGra");
    }

    void ReverseMove()
    {
        aP.GetComponent<PlayAudio>().Beeper();
        moveDirect *= -1f;
        Debug.Log("reverseMove");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "ScoreTrigger")
        {
            playerScore += 1;
        }    
        scoreText.text = "SCORE: " + playerScore.ToString("0");
    }

}

   

