using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AudioManager : MonoBehaviour
{
    [SerializeField]PhotonView view;
    public AudioClip idle;
    public AudioClip ride;
    public AudioClip starting;
    public AudioClip stoping;
    private AudioSource source;
    void Start()
    {
        if(!view.IsMine)
        {
            Destroy(this.gameObject);
        }
        source=GetComponent<AudioSource>();
    }
    void Update()
    {
        float xdir=Input.GetAxis("Horizontal");
        float ydir=Input.GetAxis("Vertical");
        source.PlayOneShot(ride);
        source.volume=0.5f;
        StartCoroutine(wait(2.5f));
        /*if(xdir==0 && ydir==0)
        {
            source.PlayOneShot(idle);
            source.volume=0.4f;
        }
        else if(xdir>0.5 || ydir>0.5)
        {
            source.PlayOneShot(ride);
            source.volume=0.7f;
        }
        else if(xdir<0.2 || ydir<0.2)
        {
            source.PlayOneShot(stoping);
            source.volume=0.3f;
        }
        else
        {
            source.PlayOneShot(starting);
            source.volume=0.5f;
        }*/
    }
    IEnumerator wait(float time)
	{
        yield return new WaitForSeconds(time);
	}
}
