﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact2 : MonoBehaviour
{
    public Transform playerPos;

     void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = playerPos.position;
        this.transform.parent = GameObject.Find("ObjectSpot").transform;

    }

     void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        
    }
}