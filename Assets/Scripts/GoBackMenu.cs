using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackMenu : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject aP;
    private void Start() {
        aP = GameObject.Find("AudioPlayer");
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
        aP.GetComponent<PlayAudio>().Button();
    }
}
