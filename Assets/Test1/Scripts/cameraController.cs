using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public GameObject Player;
    private MyBikeControll bikecontrol;
    private GameObject cameralookAt,cameraPos;
    public float speed = 0;
    private float defaltFOV = 0, desiredFOV = 0;
    [Range (0, 50)] public float smoothTime = 8;

    private void Start () {
        Player = GameObject.FindGameObjectWithTag ("Player");
        bikecontrol = Player.GetComponent<MyBikeControll> ();
        cameralookAt = Player.transform.Find ("camera lookat").gameObject;
        cameraPos = Player.transform.Find ("camera follow").gameObject;

        defaltFOV = Camera.main.fieldOfView;
        desiredFOV = defaltFOV + 15;
    }

    private void FixedUpdate () {
        follow ();
        boostFOV ();

    }
    private void follow () {
        speed = bikecontrol.motorRPM / smoothTime;
        gameObject.transform.position = Vector3.Lerp (transform.position, cameraPos.transform.position ,  Time.deltaTime * speed);
        gameObject.transform.LookAt (cameralookAt.gameObject.transform.position);
    }
    private void boostFOV () {

        if (Input.GetKey(KeyCode.LeftShift))//bikecontrol.nitrusFlag
            Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, desiredFOV, Time.deltaTime * 5);
        else
            Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, defaltFOV, Time.deltaTime * 5);

    }

}