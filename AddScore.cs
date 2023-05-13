using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    public GameObject g;
    public Text text;
    bool alreadyPassed;
    // Start is called before the first frame update
    void Start()
    {
        alreadyPassed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(g.transform.position.x - transform.position.x) < 0.1f && alreadyPassed) {
            alreadyPassed = false;
            MoveBird.score++;
            Debug.Log(MoveBird.score);
            text.text = "Score: " + MoveBird.score;
            Invoke("Cooldown", 2f);
        }
    }
    void Cooldown() {
        alreadyPassed = true;
    }
}
