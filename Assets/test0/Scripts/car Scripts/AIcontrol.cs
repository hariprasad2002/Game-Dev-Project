//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontrol : MonoBehaviour
{
    /*public WheelCollider wheelL;
    public WheelCollider wheelR;*/
    public path waypoints;
    public Transform currentwaypoint;
    public List<Transform> nodes=new List<Transform>();
    [Range(0,10)]public int distanceOffset;
    [Range(0,5)]public float steerForce;
    [HideInInspector]public float horizontal;
    [HideInInspector]public float vertical;
    private Rigidbody rb;
    private float speed=5f;
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
        waypoints=GameObject.FindGameObjectWithTag("path").GetComponent<path>();
        nodes=waypoints.nodes;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal,0,vertical) * speed;
        AIdrive();
        findDistance();
    }
    void findDistance()
    {
        Vector3 pos=gameObject.transform.position;
        float distance=Mathf.Infinity;
        for(int i=0;i<nodes.Count;i++)
        {
            Vector3 differance=nodes[i].transform.position-pos;
            float currentDist=differance.magnitude;
            if(currentDist<distance)
            {
                currentwaypoint=nodes[i+distanceOffset];
                distance=currentDist;
            }
        }
    }
    void AIdrive()
    {
        vertical=.3f;
        AIsteer();
    }
    void AIsteer()
    {
        Vector3 relative=transform.InverseTransformPoint(currentwaypoint.transform.position);
        relative /=relative.magnitude;
        horizontal=(relative.x/relative.magnitude) * steerForce;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(currentwaypoint.position,3);
    }
}
