using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class PlayerManager: MonoBehaviourPunCallbacks
{
    public TextMesh nicknameUI;
    public Text progressUI;

    void Start()
    {
        if (photonView.IsMine)
        {
            // nicknameUI.text = PhotonNetwork.NickName;
            Debug.Log("PhotonView ON");
        }
        //else
        //{
        //    nicknameUI.text = photonView.Owner.NickName;
        //}
    }


    public void AddValue(float value)
    {
        photonView.RPC("AddProgressRPC", RpcTarget.All, value);
    }

    public void SetValue(float value)
    {
        photonView.RPC("UpdateProgressRPC", RpcTarget.All, value);
    }

    [PunRPC]
    void UpdateProgressRPC(float value)
    {
        GameObject.Find("ProgressManager").GetComponent<ProgressManager>().updateProgress(value);
        Debug.Log("UpdateProgressRPC");
    }
    [PunRPC]
    void AddProgressRPC(float value)
    {
        GameObject.Find("ProgressManager").GetComponent<ProgressManager>().addProgress(1f);
        Debug.Log("AddProgressRPC");
    }
}
