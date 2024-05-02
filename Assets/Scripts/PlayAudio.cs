using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAudio : MonoBehaviour
{
    public AudioSource bat, bro, bur, but, ex, go, get, hb, bee;

    private void Start() 
    {
        DontDestroyOnLoad(this.gameObject);
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }

    public void Bat()
    {
        bat.Play();
    }

    public void Broken()
    {
        bro.Play();
    }

    public void Burning()
    {
        bur.Play();
    }

    public void StopBurning()
    {
        bur.Stop();
    }

    public void Button()
    {
        but.Play();
    }

    public void Extinguish()
    {
        ex.Play();
    }

    public void GameOver()
    {
        go.Play();
    }

    public void GetSpot()
    {
        get.Play();
    }

    public void HeartBeat()
    {
        hb.Play();
    }

    public void Beeper()
    {
        bee.Play();
    }

    private void Update() {
        if(SceneManager.GetActiveScene().buildIndex == 2 && PlayerDeath.isdead)
        {
            bur.Stop();
        }
    }
    
}
