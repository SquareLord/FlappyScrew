using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ClickToRetry : MonoBehaviour
{
    public Canvas canvas;
    public GameObject g;
    static string username = "";
    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.GetInt("numberOfTimesPlayed") == null)
        //    PlayerPrefs.SetInt("numberOfTimesPlayed", 1);
        Debug.Log("start test");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && PlayerPrefs.GetInt("start", 1) == 1) {
            PlayerPrefs.SetInt("start", 0);
            Debug.Log(username);
            PlayerPrefs.SetInt("numberOfTimesPlayed", PlayerPrefs.GetInt("numberOfTimesPlayed", 0) + 1);//increment numberoftimes played by 1  
            Debug.Log(PlayerPrefs.GetInt("numberOfTimesPlayed")); 
            PlayerPrefs.SetString("PlayerName" + PlayerPrefs.GetInt("numberOfTimesPlayed"), username);
            Debug.Log("test12");
        } 
        if (SceneManager.GetActiveScene().name == "SampleScene" && g.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text == "New Text")  {
            g.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = username;
            if (ScrollViewFill.list.ContainsKey(username))
                PlayerPrefs.SetInt("HighScoreForUsername", ScrollViewFill.list[username]);
        }
    }
    public void SwitchTo() {
        if (SceneManager.GetActiveScene().name == "MainMenu") 
            username = GameObject.Find("MenuController").GetComponent<MenuControllerScript>().UsernameInput.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene("SampleScene");
        
        
    }
    public void SettingsMenu() {
        if (canvas.GetComponent<Canvas>().enabled) {
            Time.timeScale = 1f;
            canvas.GetComponent<Canvas>().enabled = false;
            if (!g.GetComponent<MoveBird>().firstTime) {
                g.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                Destroy(g.transform.GetComponent<Rigidbody2D>());
                g.GetComponent<MoveBird>().firstTime = true;
            }
            
        } else {
            Time.timeScale = 0f;
            canvas.GetComponent<Canvas>().enabled = true;
        }
        
    }
    public void ClearHighScore() {
        PlayerPrefs.SetInt("HighScoreForUsername", 0);
        Time.timeScale = 1f;
        canvas.GetComponent<Canvas>().enabled = false;
        g.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Destroy(g.transform.GetComponent<Rigidbody2D>());
        g.GetComponent<MoveBird>().firstTime = true;
    }
    public void ExitGame() {
        PlayerPrefs.SetInt("Player" + PlayerPrefs.GetInt("numberOfTimesPlayed"), PlayerPrefs.GetInt("HighScoreForUsername"));
        
        Debug.Log(PlayerPrefs.GetInt("numberOfTimesPlayed"));
        PlayerPrefs.SetInt("HighScoreForUsername", 0);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void DisplayHighScores() {
        SceneManager.LoadScene("HighScoreDisplay");
        ScrollViewFill.fillScroll();
    }
}
