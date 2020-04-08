using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCount : MonoBehaviour
{
    public GameObject objectiveUI;
    public GameObject wall;
    void Start()
    {
        objectiveUI = GameObject.Find("ObjectiveNum");
    }

    // Update is called once per frame
    void Update()
    {
        objectiveUI.GetComponent<Text>().text = Interact.objectives.ToString();
        if(Interact.objectives == 0)
        {
            Destroy(wall);
            objectiveUI.GetComponent<Text>().text = "Complete";
        }
    }
}
