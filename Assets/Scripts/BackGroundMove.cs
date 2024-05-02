using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public Vector2 moveSpeed;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.mainTextureOffset = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerDeath.isdead && GameManager.started)
            material.mainTextureOffset += new Vector2(Time.deltaTime * PlayerMove.moveDirect * 0.01f, 0);
    }

    private void FixedUpdate() 
    {
        
    }
}
