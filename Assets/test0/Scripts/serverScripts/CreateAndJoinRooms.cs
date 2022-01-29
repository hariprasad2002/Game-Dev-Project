using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createinp;
    public InputField joininp;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createinp.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joininp.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("001");
    }
}
