//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontrol : MonoBehaviour
{
    public Transform path;
    private List<Transform> nodes;
    private int currentnode=0;
    private float maxSteerAngle=35f;
    public float turnspeed=5f;
    public WheelCollider wheelL;
    public WheelCollider wheelR;
    public WheelCollider wheelL1;
    public WheelCollider wheelR1;
    private float currentSpeed;
    private float maxSpeed=300f;
    public float maxmotorTorque=500f;
    private float maxbrakeTorque=500f;
    public bool isBraking=false;
    private Vector3 centerofmass=new Vector3(0f,-0.2f,0f);
    //sensors
    public float sensorLen=10f;
    private float frontsensorpos=2.5f;
    private float sidesensorpos=1f;
    private float sidesensorAngle=30f;
    private bool avoiding=false;
    private float targetSteerAngle=0;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass=centerofmass;
        Transform[] pathTransforms=path.GetComponentsInChildren<Transform>();
        nodes=new List<Transform>();
        for(int i=0;i<pathTransforms.Length;i++)
        {
            if(pathTransforms[i]!=path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        checkWayPointDist();
        Braking();
        sensors();
        lerpSteerAngle();
    }
    private void ApplySteer()
    {
        if(avoiding)return;
        Vector3 relvector=transform.InverseTransformPoint(nodes[currentnode].position);
        float newsteer=(relvector.x/relvector.magnitude)*maxSteerAngle;
        targetSteerAngle=newsteer;
    }
    private void Drive()
    {
        currentSpeed=2*Mathf.PI*wheelL.radius*wheelL.rpm*60/1000;
        if(currentSpeed<maxSpeed && !isBraking)
        {
            wheelR.motorTorque=maxmotorTorque;
            wheelL.motorTorque=maxmotorTorque;
        }
        else{
            wheelR.motorTorque=0;
            wheelL.motorTorque=0;
        }
    }
    private void checkWayPointDist(){
        if(Vector3.Distance(transform.position,nodes[currentnode].position)<0.5f)
        {
            if(currentnode==nodes.Count-1)
            {
                currentnode=0;
            }
            else{
                currentnode++;
            }
        }
    }
    void Braking()
    {
        if(isBraking)
        {
            wheelL1.brakeTorque=maxbrakeTorque;
            wheelR1.brakeTorque=maxbrakeTorque;
        }
        else
        {
            wheelL1.brakeTorque=0;
            wheelR1.brakeTorque=0;
        }
    }
    void sensors()
    {
        RaycastHit hit;
        Vector3 sensorstartpos=transform.position;
        sensorstartpos.y+=1f;
        float avoidmultiplier=0;
        avoiding=false;
        sensorstartpos.z+=frontsensorpos;
        //sensor at front right side
        sensorstartpos+=transform.right * sidesensorpos;
        if(Physics.Raycast(sensorstartpos,transform.forward,out hit,sensorLen))
        {
            Debug.DrawLine(sensorstartpos,hit.point);
            avoiding=true;
            avoidmultiplier-=1f;
        }
        //sensor at front right side angle
        else if(Physics.Raycast(sensorstartpos,Quaternion.AngleAxis(sidesensorAngle,transform.up)*transform.forward,out hit,sensorLen))
        {
            Debug.DrawLine(sensorstartpos,hit.point);
            avoiding=true;
            avoidmultiplier-=0.5f;
        }
        //sensor at front left side
        sensorstartpos-= transform.right * sidesensorpos * 2;
        if(Physics.Raycast(sensorstartpos,transform.forward,out hit,sensorLen))
        {
            Debug.DrawLine(sensorstartpos,hit.point);
            avoiding=true;
            avoidmultiplier+=1f;
        }
        //sensor at front left side angle
        else if(Physics.Raycast(sensorstartpos,Quaternion.AngleAxis(-sidesensorAngle,transform.up)*transform.forward,out hit,sensorLen))
        {
            Debug.DrawLine(sensorstartpos,hit.point);
            avoiding=true;
            avoidmultiplier+=0.5f;
        }
        //sensor at front
        if(avoidmultiplier==0){
        if(Physics.Raycast(sensorstartpos,transform.forward,out hit,sensorLen))
        {
            Debug.DrawLine(sensorstartpos,hit.point);
            avoiding=true;
            if(hit.normal.x<0)
            {
                avoidmultiplier= -1;
            }
            else{
                avoidmultiplier=1;
            }
        }
        }
        if(avoiding)
        {
            targetSteerAngle=maxSteerAngle*avoidmultiplier;
        }
    }
    private void lerpSteerAngle()
    {
        wheelL.steerAngle=Mathf.Lerp(wheelL.steerAngle,targetSteerAngle,Time.deltaTime*turnspeed);
        wheelR.steerAngle=Mathf.Lerp(wheelR.steerAngle,targetSteerAngle,Time.deltaTime*turnspeed);
    }
}
