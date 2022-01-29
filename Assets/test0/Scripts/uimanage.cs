//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uimanage : MonoBehaviour
{
    MainMenu menu;
    [SerializeField]private Text coinsText;
    [SerializeField]private Text distText;
    [SerializeField]private Transform player;
    private int inc=10;
    private int distance=0;
    private int coins=0;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        coinsText=GameObject.FindGameObjectWithTag("coinstext").GetComponent<Text>();
        distText=GameObject.FindGameObjectWithTag("disttext").GetComponent<Text>();
        menu=GetComponent<MainMenu>();
        coinsText.text=""+coins;
        distText.text=distance+"m/500m";
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            menu.pauseGame();
        }
    }
    void FixedUpdate()
    {
        distance=(int)player.position.z;
        if(distance==inc)
        {
            coins+=1;
            inc+=10;
            coinsText.text=""+coins;
        }
        distText.text=distance+"m/500m";
    }
}
