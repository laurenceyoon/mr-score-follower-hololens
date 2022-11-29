using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public GameObject canvasUI_run;

    void Awake()
    {
        Screen.SetResolution(1080, 720, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        PhotonNetwork.GameVersion = "1";
    }

    void Start()
    {
        Connect();
        // buttonUI.onClick.AddListener(() => Connect());
    }

    public void Connect()
    {
        // PhotonNetwork.NickName = inputFieldUI.text;
        
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("서버 접속");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 20 }, null);
        Debug.Log("서버 접속 완료");
        Debug.Log("MasterClient? : " + PhotonNetwork.IsMasterClient.ToString());
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.Instantiate("Player_mod", Vector3.zero, Quaternion.identity);

        //Debug.Log("캐릭터 생성 완료");
        Debug.Log("Photon Test");
    }

}