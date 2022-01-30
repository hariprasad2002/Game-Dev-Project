//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AudioManager : MonoBehaviour
{
    MyBikeControll mybike;
    [SerializeField]PhotonView view;
    private float bikepitch=1f;
    private float minpitch=0.05f;
    private AudioSource source;
    bool playing=false;
    void Start()
    {
        mybike=GetComponent<MyBikeControll>();
        if(!view.IsMine)
        {
            Destroy(this.gameObject);
        }
        source=GetComponent<AudioSource>();
    }
    void Update()
    {
        float vertical=Input.GetAxis("Vertical");
        source.volume=vertical;
        if(finishrace.instance.gamestarted && !playing)
            playing=true;
            source.Play();
        /*bikepitch=mybike.bikespeed;
        if(bikepitch < minpitch)
            source.pitch=minpitch;
        else
            source.pitch=bikepitch;*/
    }
}