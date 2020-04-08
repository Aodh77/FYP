using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuName : MonoBehaviour
{
    public Text playerNameDisplay;
    void Start()
    {
        if(DBManager.LoggedIn)
        {
            playerNameDisplay.text = "Player:" + DBManager.username;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
