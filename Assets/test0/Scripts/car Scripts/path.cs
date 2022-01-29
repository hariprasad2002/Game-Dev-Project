using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    public Color linecolor;
    [Range (0,5)] public float sphereSize=0.5f;
    public List<Transform> nodes=new List<Transform>();
    void OnDrawGizmos()
    {
        Gizmos.color=linecolor;
        Transform[] pathTransforms=GetComponentsInChildren<Transform>();
        nodes=new List<Transform>();
        for(int i=0;i<pathTransforms.Length;i++)
        {
            if(pathTransforms[i]!=transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
        for(int i=0;i<nodes.Count;i++)
        {
            Vector3 currentnode=nodes[i].position;
            Vector3 previousnode=Vector3.zero;
            if(i!=0)//>
            {
                previousnode=nodes[i-1].position;
            }
            else if(i==0)
            {
                previousnode=nodes[nodes.Count-1].position;
            }
            Gizmos.DrawLine(previousnode,currentnode);
            Gizmos.DrawWireSphere(currentnode,sphereSize);
        }
    }
}
