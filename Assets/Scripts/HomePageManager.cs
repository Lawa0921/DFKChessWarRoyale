using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class HomePageManager : MonoBehaviour {
    [SerializeField] private GameObject AddressInput;
    public const string HEXPATTERN = @"([^A-Fa-f0-9]|\s+?)+";

    public void OnClickLogin()
    {
        string inputAddress = AddressInput.GetComponent<InputField>().text;

        if (IsVaildAddress(inputAddress))
        {
            Debug.Log(inputAddress);
        }
        else
        {
            Debug.Log("address format is invaild");
        }
    }

    private bool IsVaildAddress(string address)
    {
        return address.Length == 42 && address.StartsWith("0x") && System.Text.RegularExpressions.Regex.IsMatch(address, HEXPATTERN); ;
    }
}
