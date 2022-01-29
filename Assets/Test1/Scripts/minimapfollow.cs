//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class minimapfollow : MonoBehaviour
{
    [SerializeField]private Transform player;
    public GameObject minimap;
    [SerializeField]PhotonView view;
    private void Start() {
        //view=GetComponent<PhotonView>();
        if(player==null)
            player=GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void LateUpdate() {
        if(finishrace.instance.gamecompleted)
        {
            minimap.SetActive(false);
            return;
        }
        Vector3 pos=player.position;
        pos.y=transform.position.y;
        transform.position=pos;

        transform.rotation=Quaternion.Euler(90f,player.eulerAngles.y,0f);
    }
}
