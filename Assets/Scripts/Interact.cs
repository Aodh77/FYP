using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    Vector3 objectPos;
    public static int objectives = 0; 

    
    

    private void Start()
    {
        GameEvents.current.onItemTrigger += ItemTrigger;
    }

    private void Awake()
    {
        objectives++;
    }
    void Update()
    {

    }

    private void ItemTrigger()
    {
        Debug.Log("triggered");
        objectives--;
        
    }
}
