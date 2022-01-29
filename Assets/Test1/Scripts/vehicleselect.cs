//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vehicleselect : MonoBehaviour
{
    public GameObject[] bikes;
    public Text pricestext;
    public Text Amounttext;
    private float[] prices={1500000,2000000,2500000,2500000,1000000};
    [Range(0,20)]public float rotatespeed;
    public GameObject cylinder;
    private GameObject player;
    private int k=0;
    private GameObject currentbike;
    private float amount;
    private void Start() {
        if(!PlayerPrefs.HasKey("Amount"))
		{
			PlayerPrefs.SetFloat("Amount",10000f);
		}
        amount=PlayerPrefs.GetFloat("Amount");
        Amounttext.text="$"+amount;
        bikes[0].SetActive(true);
        pricestext.text="$"+prices[0];
        currentbike=bikes[0];
        for(int i=1;i<bikes.Length;i++)
        {
            bikes[i].SetActive(false);
        }
    }
    void FixedUpdate()
    {
        if(amount!=PlayerPrefs.GetFloat("Amount"))
        {
            amount=PlayerPrefs.GetFloat("Amount");
            Amounttext.text="$"+amount;
        }
        player=GameObject.FindGameObjectWithTag("bike");
        cylinder.transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);
        player.transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);
    }
    public void nextbtn()
    {
        if(k>=bikes.Length-1)
            return;
        k+=1;
        currentbike.SetActive(false);
        currentbike=bikes[k];
        currentbike.SetActive(true);
        currentbike.transform.position=new Vector3(currentbike.transform.position.x,currentbike.transform.position.y+1f,currentbike.transform.position.z);
        pricestext.text="$"+prices[k];
    }
    public void previousbtn()
    {
        if(k<=0)
            return;
        k-=1;
        currentbike.SetActive(false);
        currentbike=bikes[k];
        currentbike.SetActive(true);
        currentbike.transform.position=new Vector3(currentbike.transform.position.x,currentbike.transform.position.y+1f,currentbike.transform.position.z);
        pricestext.text="$"+prices[k];
    }
}
