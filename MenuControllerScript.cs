using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI.InputField;

public class MenuControllerScript : MonoBehaviour
{
    string VersionName = "0.1";
    public GameObject UsernameInput;
    public GameObject StartButton;

    void Awake() {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }
    void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    // Start is called before the first frame update
    void Start()
    {
        UsernameInput.gameObject.SetActive(true);
        StartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UsernameInputField() {
        Debug.Log(UsernameInput.GetComponent<TMP_InputField>());
        if (UsernameInput.GetComponent<TMP_InputField>().text.Length >= 5) StartButton.SetActive(true);
        else StartButton.SetActive(false);
    }
}






























































