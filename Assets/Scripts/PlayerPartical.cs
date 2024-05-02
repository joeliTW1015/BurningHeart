using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartical : MonoBehaviour
{
    ParticleSystem parsys;
    // Start is called before the first frame update
    void Start()
    {
        parsys = GetComponent<ParticleSystem>();
        var parmain = parsys.main;
        parmain.gravityModifier = -1f; 
    }

    // Update is called once per frame
    void Update()
    {
        var parmain = parsys.main;
        parmain.gravityModifier = -1f * PlayerMove.graDirect; 
        var parfol = parsys.forceOverLifetime;
        parfol.x = -20f * PlayerMove.moveDirect;
    }
}
