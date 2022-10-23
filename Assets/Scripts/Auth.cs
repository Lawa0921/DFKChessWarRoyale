using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FusedVR.Crypto;

public class Auth : MonoBehaviour {
    async void Start() {
        Debug.Log("lalala");
        ChainAuthManager mngr = await ChainAuthManager.Register("bag571ivy3470@gmail.com", "DFKChessBattle");
        Debug.Log("lalala");
        await mngr.GetMagicLink();
        Debug.Log("lalala");
        if (await mngr.AwaitLogin()) {
            string address = mngr.GetAddress();
            Debug.Log(address);
        }
    }
}
