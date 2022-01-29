using System.Collections;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
    PhotonView view;
    [SerializeField] private Transform target;
    [SerializeField]private Vector3 offset;
    [SerializeField]private float smoothness = 0.07f;

    private void Start()
    {
        view=GetComponent<PhotonView>();
        offset = new Vector3(0,2.5f,-3);
    }
    void FixedUpdate()
    {
        if(view.IsMine)
        {
            Vector3 desiredpos = target.position + offset;
            Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothness);
            transform.position = smoothedpos;
        }
        //transform.LookAt(target);
    }
}
