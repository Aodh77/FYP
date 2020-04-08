using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public GameObject itemDis;

    // Update is called once per frame
    void Update()
    {
        Vector3 disPos = Camera.main.WorldToScreenPoint(this.transform.position);
        itemDis.transform.position = disPos;
    }
}
