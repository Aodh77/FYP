using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    Vector3 objectPos;
    public static int objectives = 0; 

    
    public GameObject item;
    public GameObject tempParent;
    
    public bool isHolding = false;

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
        if(isHolding==true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            

            if (Input.GetMouseButtonDown(1))
            {

            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            


        }
             
    }

    void OnMouseDown()
    {
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.transform.position = objectPos;
    }

    void OnMouseUp()
    {
        isHolding = false;
    }

    private void ItemTrigger()
    {
        Debug.Log("triggered");
        objectives--;
        
    }
}
