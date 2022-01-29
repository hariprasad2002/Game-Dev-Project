using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerprefab;
    [Range(-10,20)]public int minX= -8;
    [Range(-10,20)]public int minZ=0;
    [Range(-10,20)]public int maxX=8;
    [Range(-10,20)]public float maxZ=5;
    
    void Start()
    {
        Vector3 randomPos=new Vector3(Random.Range(minX,maxX),10.6f,Random.Range(minZ,maxZ));
        PhotonNetwork.Instantiate(playerprefab.name,randomPos,Quaternion.identity);
    }
}
