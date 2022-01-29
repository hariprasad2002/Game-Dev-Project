using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carWheel : MonoBehaviour
{
    public WheelCollider wheelCollider;
    private Vector3 wheelPos=new Vector3();
    private Quaternion wheelRot=new Quaternion();
    void Update()
    {
        wheelCollider.GetWorldPose(out wheelPos,out wheelRot);
        transform.position=wheelPos;
        transform.rotation=wheelRot;
    }
}
