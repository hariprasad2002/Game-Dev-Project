//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ScoreBoardItem : MonoBehaviour
{
    public static ScoreBoardItem instance;
    public Text username;
    public Text status;
    public bool update=true;
    private void Start() {
        instance=this;
    }
    public void Initialize(Player player)
    {
        username.text=player.NickName;
        status.text=Laptimer.instance.totalTime;
    }
    private void Update() {
        if(update)
        {
            updatelaptime();
        }
    }
    void updatelaptime()
    {
        status.text=Laptimer.instance.totalTime;
    }
}
