using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceModify : MonoBehaviour
{
    public GameObject area1Camera;
    public GameObject area2Camera;
    
    public GameObject area2Enter;
    public GameObject area2Exit;
    public GameObject area3Enter;
    public GameObject area3Exit;
    public GameObject player;
    public GameObject area2LBorn;
    public GameObject area2MBorn;
    public GameObject area1Born;
    public GameObject area3Born;
    public bool canEntryLabo;
    
    void Start()
    {
        canEntryLabo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject == area2Enter)
        {
            player.transform.position = area2LBorn.transform.position;
        }
       
        if (other.gameObject.CompareTag("Player") && gameObject == area2Exit)
        {
            player.transform.position = area1Born.transform.position;
        }
        
        if (other.gameObject.CompareTag("Player") && gameObject == area3Enter)
        {
            area1Camera.SetActive(false);
            area2Camera.SetActive(true);
            player.transform.position = area3Born.transform.position;
        }
        
        if (other.gameObject.CompareTag("Player") && gameObject == area3Exit)
        {
            area2Camera.SetActive(false);
            area1Camera.SetActive(true);
            player.transform.position = area2MBorn.transform.position;
        }
    }
}
