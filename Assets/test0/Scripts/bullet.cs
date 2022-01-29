using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hiteffect;
    public float deathtime = 5f;
    private void Start()
    {
        StartCoroutine(death());
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag != "land")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator death()
    {
        while (true)
        {
            yield return new WaitForSeconds(deathtime);
            Destroy(gameObject);
        }
    }
}
