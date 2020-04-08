using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Connect : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject PartnerPanel = null;
    [SerializeField] private GameObject StatusPanel = null;
    [SerializeField] private TextMeshProUGUI StatusText = null;


    private bool isConnecting = false;

    private const int MaxPlayersPerRoom = 2;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    public void FindOpponent()
    {
        isConnecting = true;

        PartnerPanel.SetActive(false);
        StatusPanel.SetActive(true);

        StatusText.text = "Searching...";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnected To Master");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        StatusPanel.SetActive(false);
        PartnerPanel.SetActive(true);


        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No clients");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Client joined");

        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;


        if(playerCount != MaxPlayersPerRoom)
        {
            StatusText.text = "Waiting for other player ";
        }
        else
        {
            StatusText.text = "Partner Found";
        }
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            StatusText.text = "Opponet found";

            PhotonNetwork.LoadLevel("TestLevel");
        }
    }
}

