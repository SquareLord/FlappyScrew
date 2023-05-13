using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class MoveBird : MonoBehaviour
{
    public bool cooldown, gameOver, firstTime, rotationUnfreeze, settingsUnfreeze;
    public static int score;
    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = true;
        gameOver = true;
        firstTime = true;
        rotationUnfreeze = false;
        settingsUnfreeze = false;

        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(0f);
        // Use the QuickVolume method to create a volume with a priority of 100, and assign the vignette to this volume
        m_Volume = PostProcessManager.instance.QuickVolume(GameObject.Find("Main Camera").layer, 100f, m_Vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown && gameOver) {
            if (firstTime) { 
                firstTime = false;
                transform.gameObject.AddComponent<Rigidbody2D>();
                transform.GetComponent<Rigidbody2D>().freezeRotation = true;
                rotationUnfreeze = true;
            } else {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, 5f);
            }
            cooldown = false;
            
            Invoke("CooldownSet", 0.25f);
        }
        if (transform.position.y != 0) {
            m_Vignette.intensity.value = Mathf.Clamp(Mathf.Abs(transform.position.y)/5, 0f, 0.5f); 
        }  
    }
    void CooldownSet() {
        cooldown = true;
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (gameOver) {
            if (collision.gameObject.tag.Equals("Barrier")) {
                transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameOver = false;
                SceneManager.LoadScene("Menu");
            }
        }
    }
    void FixedUpdate() {
        if (rotationUnfreeze && !firstTime) {
            float tiltAngle = Mathf.Clamp(transform.GetComponent<Rigidbody2D>().velocity.y*2f + 90, 70, 110);
            transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);
        }
        
    }
}
