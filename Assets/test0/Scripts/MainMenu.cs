//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviourPunCallbacks
{
    //[SerializeField]private AudioClip clip;
    //[SerializeField]private AudioSource source;
    private GameObject gameoverpanel;
    [HideInInspector]public bool pausegame=false;
    private GameObject pausemenupanel;
    void Start()
    {
        gameoverpanel = GameObject.FindGameObjectWithTag("gameoverpanel");
        pausemenupanel = GameObject.FindGameObjectWithTag("pausemenupanel");
        //source.PlayOneShot(clip);
    }
    public void pauseGame()
    {
        pausegame=true;
        Time.timeScale=0;
        pausemenupanel.SetActive(true);
    }
    public void resumeGame()
    {
        Time.timeScale=1;
        pausemenupanel.SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackGame()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closing!!!");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
