//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuelsystem : MonoBehaviour
{
    [HideInInspector]public float currentFuel;
    private float maxFuel=1000f;
    [SerializeField]private Slider fuelslider;
    [HideInInspector]public float fuelconsumptionrate;
    public Gradient fuelgradient;
    [SerializeField]private Image fill;

    void Start()
    {
        fuelslider=GameObject.FindGameObjectWithTag("fuelslider").GetComponent<Slider>();
        fill=GameObject.FindGameObjectWithTag("fuelfill").GetComponent<Image>();
        currentFuel=maxFuel;
        fuelslider.maxValue=maxFuel;
        updateui();
    }
    public void fuelconsume()
    {
        currentFuel -= Time.deltaTime * fuelconsumptionrate;
        updateui();
    }
    void updateui()
    {
        fuelslider.value=currentFuel;
        fill.color=fuelgradient.Evaluate(fuelslider.normalizedValue);
        if(currentFuel<=0)
        {
            currentFuel=0;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fuelstation"))
        {
            currentFuel+=200f;
            if(currentFuel>=maxFuel)
            {
                currentFuel=maxFuel;
            }
            updateui();
            Destroy(collision.gameObject,5f);
        }
    }*/
    private void OnTriggerStay(Collider collision)
    {
        if(collision.CompareTag("fuelstation"))
        {
            currentFuel+=Time.deltaTime * 80f;
            if(currentFuel>=maxFuel)
            {
                currentFuel=maxFuel;
            }
            updateui();
        }
    }
}
