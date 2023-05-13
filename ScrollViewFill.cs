using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollViewFill : MonoBehaviour
{
    public GameObject textCloning;
    public static Dictionary<string, int> list;
    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        list = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "HighScoreDisplay" && b) {
            Debug.Log("running");
            b = false;
            for (int i = 1; i < list.Count + 1; i++) {
                GameObject g = Instantiate(GameObject.Find("ScoreText"));
                g.transform.parent = GameObject.Find("Content").transform;
                g.GetComponent<Text>().text = PlayerPrefs.GetInt("Player" + i) + "        " + PlayerPrefs.GetString("PlayerName" + i).ToString();
            }
            
        }
    }
    public static void fillScroll() { //TODO improve sorting alg but not a priority
        
        int i = 1;
        while (true) {
            if (PlayerPrefs.GetInt("Player" + i, -1) == -1) break; 
            
            list.Add(PlayerPrefs.GetString("PlayerName" + i), PlayerPrefs.GetInt("Player" + i));    
            //Debug.Log(list.ToString());
            i++;
        }
    }
}
