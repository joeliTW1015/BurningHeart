using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScence : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highestScore;
    GameObject aP;
    private void Start() {
        highestScore.text = "Highest Score :  " + PlayerPrefs.GetInt("HighestScore", 0).ToString("0");
        aP = GameObject.Find("AudioPlayer");
        aP.GetComponent<PlayAudio>().Burning();
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void StartGame()
    {
        aP.GetComponent<PlayAudio>().StopBurning();
        SceneManager.LoadScene(2);
    }

    public void HowTOPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void ButtonSound()
    {
        aP.GetComponent<PlayAudio>().Button();
    }
}
