using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : MonoBehaviour
{
    public Text timer;
    public GameObject endMenu;
    //private float startTime;
    private int time;
    //private bool finnished = false;
    private string username;
    private int finaltime;
    //private float t;

    void Start()
    {
        StartTimer();
        
    }

    /*
    void Update()
    {
       
        float t = Time.time - startTime;
        if (finnished)
        {
            
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timer.text = minutes + ":" + seconds;
        
    }
    */


    public void Finnish()
    {
        CancelInvoke();
        timer.color = Color.yellow;
        bool isActive = endMenu.activeSelf;
        endMenu.SetActive(!isActive);
        Cursor.lockState = CursorLockMode.None;



        if(DBManager.time != 0)
        {
            if (time <= 0 || time >= DBManager.time)
            {

                Debug.Log("time value" + DBManager.time);
                Debug.Log("big time value" + time);
            }
            else
            {
                DBManager.time = time;
                Debug.Log("time value" + DBManager.time);
            }
        }
        else
        {
            DBManager.time = time;
            Debug.Log("time value" + DBManager.time);
        }
        
    }

    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrementTime", 1, 1);
    }


    void IncrementTime()
    {
        time += 1;
        timer.text = time + ":seconds";


    }


    public void CallSaveTime()
    {
        StartCoroutine(SavePlayerTime());
    }


    IEnumerator SavePlayerTime()
    {
        username = DBManager.username;
        finaltime = DBManager.time;
        WWWForm form = new WWWForm();
        form.AddField("name", username);
        form.AddField("time", finaltime);
        
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/savedata.php", form);
       // www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
        
        if (www.downloadHandler.text[0].Equals('0'))
        {
            Debug.Log("saved");
        }
        else
        {
            Debug.Log("save failed");
            Debug.Log(www.downloadHandler.text);
        }

        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
