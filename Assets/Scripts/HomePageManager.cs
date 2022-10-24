using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class HomePageManager : MonoBehaviour {
    [SerializeField] private GameObject AddressInput;
    public void OnClickLogin()
    {
        string inputAddress = AddressInput.GetComponent<InputField>().text;

        if (IsAddress(inputAddress))
        {
            Debug.Log(inputAddress);
        }
        else
        {
            Debug.Log("address format is invaild");
        }
    }

    private bool IsAddress(string address)
    {
        Regex reg = new Regex("^0x[a-fA-F0-9]{40}$");

        return reg.IsMatch(address);
    }
}
