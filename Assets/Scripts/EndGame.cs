using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EndGame : MonoBehaviour
{

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void CallSaveTime()
    {
        StartCoroutine(SavePlayerTime());
    }


    IEnumerator SavePlayerTime()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("time", DBManager.time);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if (www.downloadHandler.text[0] == '0')
        {
            Debug.Log("game saved");
        }
        else
        {
            Debug.Log("save failed");
        }

        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
