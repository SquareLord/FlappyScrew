using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartOnMenu : MonoBehaviour
{
    public Text text;
    public ScrollView scroll;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") < MoveBird.score) {
            PlayerPrefs.SetInt("HighScore", MoveBird.score);
        }
        if (PlayerPrefs.GetInt("HighScoreForUsername") < MoveBird.score) {
            PlayerPrefs.SetInt("HighScoreForUsername", MoveBird.score);
        }
            
        text.text = "Game Over! \nHigh Score: " + PlayerPrefs.GetInt("HighScoreForUsername") + " \nHigh Score of All Time: " + PlayerPrefs.GetInt("HighScore") + "\nPress the button to retry!";
        MoveBird.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
