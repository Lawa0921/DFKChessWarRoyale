using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HomePageManager : MonoBehaviour
{
    public void OnClickLogin()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("clicked login");
    }

    public void OnClickSignUp()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("clicked sign up");
    }
}
