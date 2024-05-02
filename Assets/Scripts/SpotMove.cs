using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotMove : MonoBehaviour
{
    // Start is called before the first frame update
    public bool goup;
    public float diltaY;
    public float speed;
    public float range;
    void Start()
    {
        diltaY = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        if(goup)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            diltaY += speed * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            diltaY -= speed * Time.deltaTime;
        }

        if(diltaY > range && goup)
        {
            goup = false;
        }
        else if(diltaY < -range && !goup)
        {
            goup = true;
        }


    }
}
