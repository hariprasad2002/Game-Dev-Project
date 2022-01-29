//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ScoreBoard : MonoBehaviourPunCallbacks
{
    [SerializeField]Transform container;
    [SerializeField]GameObject scoreboarditemprefab;
    Dictionary<Player,ScoreBoardItem> scoreboarditems=new Dictionary<Player, ScoreBoardItem>();
    void Start()
    {
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            Addscoreboarditem(player);
        }
    }
    void Addscoreboarditem(Player player)
    {
        ScoreBoardItem item=Instantiate(scoreboarditemprefab,container).GetComponent<ScoreBoardItem>();
        item.Initialize(player);
        scoreboarditems[player]=item;
    }
    void Removescoreboarditem(Player player)
    {
        Destroy(scoreboarditems[player].gameObject);
        scoreboarditems.Remove(player);
    }
    public override void OnPlayerEnteredRoom(Player newplayer)
    {
        Addscoreboarditem(newplayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Removescoreboarditem(otherPlayer);
    }
}
