using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LeaderBoard : MonoBehaviour
{
    public string[] fullTimes;
    void Start()
    {
        startGetTimes();
    }

    public void startGetTimes()
    {
        StartCoroutine(GetTimes());
    }


    IEnumerator GetTimes()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/gettime.php");
        yield return www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("get times failed");
        }
        else
        {
            string timeString = www.downloadHandler.text;

            fullTimes = timeString.Split(";"[0]);

            DBManager.besttimes = fullTimes;

            for(int i =0; i < fullTimes.Length; i++)
            {
                Debug.Log(DBManager.besttimes[i]);
            }

            GameObject.Find("PrefabForCanvasChild").SendMessage("getScrollEntrys");
        }
    }


}
