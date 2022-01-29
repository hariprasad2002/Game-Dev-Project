using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class countdown : MonoBehaviourPunCallbacks
{
    playercontrol playercontrol;
    float currentTime=0;
    [SerializeField]private float startTime=15f;
    [SerializeField]private Text countdowntext;
    [SerializeField]private Text bestscoretext;
    [SerializeField]private GameObject gameoverpanel;
    [SerializeField]private Color textcolor=Color.red;
    private GameObject player;
    [SerializeField]private int waitingtime=5;
    private bool starttimer=false;

    void Start()
    {
        playercontrol=GetComponent<playercontrol>();
        //StartCoroutine(wait());
        player=GameObject.FindGameObjectWithTag("Player");
        currentTime=startTime;
        countdowntext.text=""+(int)currentTime;
    }
    void Update()
    {
        if(playercontrol.outoffuel)
        {
            gameovermenu();
        }
    }
    /*void Update()
    {
        wait();
        if(starttimer)
        {
            Countdown();
        }
    }
    void Countdown()
    {
        if(currentTime>0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        else{
            starttimer=false;
            reasontext="TimeOut!!!";
            gameovermenu();
        }
        if(currentTime<10)
        {
            countdowntext.color=textcolor;
            countdowntext.text="0"+(int)currentTime;
        }
        else
        {
            countdowntext.text=""+(int)currentTime;
        }
    }*/
    public void gameovermenu()
    {
        Time.timeScale=0;
        gameoverpanel.SetActive(true);
        if(photonView.IsMine)
        {
        bestscoretext.text="Best:"+(int)player.transform.position.z+"m";
        }
    }
    /*IEnumerator wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitingtime);
            starttimer=true;
        }
    }*/
}
