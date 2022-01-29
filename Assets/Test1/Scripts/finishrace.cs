using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finishrace : MonoBehaviourPunCallbacks
{
    public static finishrace instance;
    public Text countdown;
    public bool gamecompleted=false;
    public bool gamestarted=false;
    float time=5f;
    private void Start() {
        instance=this;
        StartCoroutine(wait());
    }
    private void Update() {
        if(time<=0)
        {
            countdown.gameObject.SetActive(false);
            return;
        }
        countdown.text=""+(int)time;
        time -= 1 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("triggered");
        gamecompleted=true;
        MenuManager.Instance.OpenMenu("gamecompletedmenu");
        //PhotonNetwork.LoadLevel(2);
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        gamestarted=true;
    }
}
