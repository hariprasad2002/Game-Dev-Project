using UnityEngine;
using Photon.Pun;

public class scriptsControl : MonoBehaviourPunCallbacks
{
    public GameObject localCam;
    void Start()
    {
        if(!photonView.IsMine)
        {
            localCam.SetActive(false);
            MonoBehaviour[] scripts=GetComponents<MonoBehaviour>();
            for(int i=0;i<scripts.Length;i++)
            {
                if(scripts[i] is scriptsControl)continue;
                else if(scripts[i] is PhotonView)continue;
                scripts[i].enabled=false;
            }
        }
    }
}
