using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Connect2 : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject cancelButton;
    [SerializeField] private int RoomSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        startButton.SetActive(true);
    }
    // Start is called before the first frame update
    public void BStart()
    {
        startButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("quick Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("failed room join");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating room ");
        int randomRoomNumber = Random.Range(0, 100);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("failed to create room");
        CreateRoom();
    }

    public void QuickCancel()
    {
        cancelButton.SetActive(false);
        startButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
