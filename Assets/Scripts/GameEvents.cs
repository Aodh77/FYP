using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
 
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onItemTrigger;
    public event Action onItemSpawn;

    public void ItemTigger()
    {
        if (onItemTrigger != null)
        {
            onItemTrigger();
        }
    }

    public  void itemSpawn()
    {
        if (onItemSpawn != null)
        {
            onItemSpawn();
        }
    }

}
