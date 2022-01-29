//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class carControl1 : MonoBehaviour
{
    public WheelCollider wheelL;
    public WheelCollider wheelR;
    private float currentSpeed;
    private float maxSpeed=300f;
    public float maxmotorTorque=500f;
    private Vector3 centerofmass=new Vector3(0f,-0.2f,0f);
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass=centerofmass;
    }

    void FixedUpdate()
    {
        //ApplySteer();
        Drive();
    }
    private void Drive()
    {
        currentSpeed=2*Mathf.PI*wheelL.radius*wheelL.rpm*60/1000;
        if(currentSpeed<maxSpeed)
        {
            wheelR.motorTorque=maxmotorTorque;
            wheelL.motorTorque=maxmotorTorque;
        }
        else{
            wheelR.motorTorque=0;
            wheelL.motorTorque=0;
        }
    }
}
