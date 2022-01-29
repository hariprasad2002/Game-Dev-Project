//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class BillBoard : MonoBehaviour
{
    [SerializeField]PhotonView view;
    [SerializeField]Text nametext;
	private Camera cam;
	public Text amounttext;
	private bool amountadded=false;

    private void Start() {
		if(!PlayerPrefs.HasKey("Amount"))
		{
			PlayerPrefs.SetFloat("Amount",10000f);
		}
		amounttext.text="$"+PlayerPrefs.GetFloat("Amount");
		cam=GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		if(!view.IsMine)
		{
        	nametext.text=view.Owner.NickName;
			//Destroy(GameObject.FindWithTag("canvas").GetComponent<Laptimer>());
		}
		else
		{
			nametext.text="";
		}
    }
	void Update()
	{
		if(finishrace.instance.gamecompleted && !amountadded)
		{
			AddAmount(30000f);
			amountadded=true;
		}
		/*if(cam == null)
			cam = FindObjectOfType<Camera>();

		if(cam == null)
			return;*/

		transform.LookAt(cam.transform);
		transform.Rotate(Vector3.up * 180);
	}
	public void AddAmount(float value)
	{
		float amount = PlayerPrefs.GetFloat("Amount");
		PlayerPrefs.SetFloat("Amount",amount+value);
		amounttext.text="$"+PlayerPrefs.GetFloat("Amount");
	}
}
