using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, spawnLine, pauseMenu, endGameMenu, aP;
    public Text countText, hintText, endGameScoreText, highestScoreText;

    float tempTime;
    int countTextValue;
    public static bool started;

    void Start()
    {
        aP = GameObject.Find("AudioPlayer");
        started = false;
        countTextValue = 3;
        tempTime = 5f;
        countText.text = "";
        hintText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            tempTime -= Time.deltaTime;
            if(countTextValue > 0)
                countText.text = (countTextValue).ToString("0");
            
            if(tempTime < countTextValue + 1)
            {
                countTextValue -= 1;
                if(countTextValue == 0)
                {
                    countText.text = "START!";
                    aP.GetComponent<PlayAudio>().Beeper();
                }
                else if(countTextValue > 0)
                {
                    aP.GetComponent<PlayAudio>().Beeper();
                }
            }
            
            if(tempTime <= 0)
            {
                countText.text = "";
                player.SetActive(true);
                spawnLine.SetActive(true);
                started = true;
                aP.GetComponent<PlayAudio>().Burning();
            }
        }
    }

    public void GamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameRestart()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameLoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit");
        Application.Quit();
    }

    public void EndGamePanel()
    {
        PlayerPrefs.SetInt("HighestScore", Mathf.Max(PlayerMove.HighestScore, PlayerMove.playerScore));
        endGameMenu.SetActive(true);
        endGameScoreText.text = "Score:  " + PlayerMove.playerScore.ToString("0");
        highestScoreText.text = "Highest Score:  " + PlayerPrefs.GetInt("HighestScore", 0).ToString("0");
        Time.timeScale = 0f;

    }

    public void ButtonSound()
    {
        aP.GetComponent<PlayAudio>().Button();
    }

}
