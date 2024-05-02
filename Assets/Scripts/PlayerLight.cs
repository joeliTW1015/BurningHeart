using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    public Light2D lit;
    GameObject aP;
    // Start is called before the first frame update
    void Start()
    {
        aP = GameObject.Find("AudioPlayer");
        lit = GetComponentInChildren<Light2D>();
        lit.pointLightOuterRadius = 13f;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerDeath.isdead)
        {
            lit.pointLightOuterRadius = 0f;
            lit.intensity = 0f;
        }
        else if(lit.pointLightOuterRadius <= 0.01f)
        {
            GetComponent<PlayerDeath>().Extinguished();
        }
        else
        {
            lit.pointLightOuterRadius -= Time.deltaTime * 0.4f ;
            lit.intensity = lit.pointLightOuterRadius * 0.2f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Spot")
        {
            aP.GetComponent<PlayAudio>().GetSpot();
            lit.pointLightOuterRadius = 13f;
            Destroy(other.gameObject);
        }   
    }
}
