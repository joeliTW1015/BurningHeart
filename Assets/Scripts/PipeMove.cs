using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float pipeSpeed;
    private void Start() {
        pipeSpeed = 7f;
    }
    
    private void FixedUpdate() 
    {
        if(!PlayerDeath.isdead)
            transform.position += new Vector3(-pipeSpeed * Time.deltaTime * PlayerMove.moveDirect, 0, 0);
        if(Mathf.Abs(transform.position.x) > 10.1f)
            Destroy(gameObject);
        if(PlayerMove.playerScore < 30)
            pipeSpeed = PlayerMove.playerScore * 0.1f + 7f;
        else pipeSpeed = 10f;
    }

    
}
