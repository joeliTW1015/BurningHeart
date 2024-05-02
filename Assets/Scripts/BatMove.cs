using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    GameObject player, aP;
    SpriteRenderer rd;
    public Color batColor;
    public float speed;
    bool startDash;

    Vector3 playerAng;

    // Start is called before the first frame update
    void Start()
    {
        batColor = Color.black;
        player = GameObject.Find("Player");
        aP = GameObject.Find("AudioPlayer");
        rd = GetComponent<SpriteRenderer>();
        rd.color = batColor;
        startDash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rd.color.r < 1)
        {
            batColor += new Color(Time.deltaTime * 0.5f, Time.deltaTime * 0.5f, Time.deltaTime * 0.5f, 0);
            rd.color = batColor;
            playerAng = (player.transform.position - transform.position);
            playerAng.Normalize();
        }
        else
        {
            if(startDash == false)
            {
                aP.GetComponent<PlayAudio>().Bat();
                startDash = true;
            }
            if(! PlayerDeath.isdead)
                transform.position +=  playerAng *speed * Time.deltaTime;
        }

        if(Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 6)
        {
            Destroy(this.gameObject);
        }
    }

    
}
