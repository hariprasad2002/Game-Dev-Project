using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
//using Photon.Realtime;

public class leaveroom : MonoBehaviour
{
    private Button exitroom;
    private void Start() {
        //Debug.Log("leftbutton");
        exitroom=GetComponent<Button>();
    }
    public void onclick()
    {
        Debug.Log("left");
        StartCoroutine(leftroom());
    }
    IEnumerator leftroom()
	{
		PhotonNetwork.LeaveRoom();
		MenuManager.Instance.OpenMenu("loadingmenu");
		while(PhotonNetwork.InRoom)
		    yield return null;
		SceneManager.LoadScene(0);
	}
}
