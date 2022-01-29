//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Laptimer : MonoBehaviour
{
    public static Laptimer instance;
    public string totalTime="";
    private string minutes;
    private string seconds;
    private string milliseconds;
    private int minutecount;
    private int secondcount;
    private float millicount;
    private void Start() {
        instance=this;
    }
    void Update()
    {
        if(!finishrace.instance.gamestarted)
        {
            return;
        }
        if(finishrace.instance.gamecompleted)
        {
            return;
        }
        millicount+=Time.deltaTime * 10;
        milliseconds=""+millicount.ToString("F0");
        if(millicount>=10)
        {
            millicount=0;
            secondcount+=1;
        }
        if(secondcount<=9)
        {
            seconds="0"+secondcount;
        }
        else
        {
            seconds=""+secondcount;
        }
        if(secondcount>=60)
        {
            secondcount=0;
            minutecount+=1;
        }
        if(minutecount<=9)
        {
            minutes="0"+minutecount;
        }
        else
        {
            minutes=""+minutecount;
        }
        totalTime=minutes+":"+seconds+"."+milliseconds;
        //Debug.Log(totalTime);
    }
}
