﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Player").SendMessage("Finnish");
    }
}
