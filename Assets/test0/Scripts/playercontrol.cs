//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class playercontrol : MonoBehaviour
{
    public Canvas canvas;
    PhotonView view;
    Fuelsystem fuelsystem;
    private Rigidbody rb;
    public bool outoffuel=false;
    [SerializeField]private float consumefuel=2f;
    /*countdown countdown;
    //private float speed=5f;

    void Start()
    {
        countdown=GetComponent<countdown>();
        Time.timeScale=1;
        fuelsystem=GetComponent<Fuelsystem>();
        rb = GetComponent<Rigidbody>();
        //source.PlayOneShot(clip1);
    }
    private void Update()
    {
        float Xdir = Input.GetAxis("Horizontal")*speed;
        float Ydir = Input.GetAxis("Vertical")*speed;
        //rb.velocity = new Vector3(Xdir,0,Ydir);//Xdir,0,Ydir
        if(fuelsystem.currentFuel <=0)
        {
            outoffuel=true;
        }
        float rate=rb.velocity.x+rb.velocity.y+rb.velocity.z;
        if(rate<0)
        {
            rate=(-rate);
        }
        fuelsystem.fuelconsumptionrate = rate*consumefuel;
        fuelsystem.fuelconsume();
    }*/
    private void Start() {
        view=GetComponent<PhotonView>();
        if(!view.IsMine)
        {
            Destroy(canvas);
        }
    }
    void Update()
    {
        if(!view.IsMine)
           return;
        //float rate=rb.velocity.x+rb.velocity.y+rb.velocity.z;
        float rate=1;
        if(rate<0)
        {
            rate=(-rate);
        }
        fuelsystem.fuelconsumptionrate = rate*consumefuel;
        fuelsystem.fuelconsume();
    }
}