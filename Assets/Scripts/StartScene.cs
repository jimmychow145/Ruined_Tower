using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
    private bool held = false;
    public float holdTime = 3.0f; // how long you need to hold to trigger the effect
 
    private float startTime = 0f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("Music"));

    }

    // Update is called once per frame
    void Update()
    {   
        HandleGameExit();

        if (Input.GetKey(KeyCode.Alpha1) && SceneManager.GetActiveScene().name == "Start Scene")
        {
            this.GetComponent<SceneChanger>().ChangeScene("HowToPlayScene");
            
        }
        if(Input.GetKeyDown("a"))
        {
            this.GetComponent<SceneChanger>().ChangeScene("GameScene");
        }
    }

    // This will check to see if the Escape key has been held down for holdTime time
    private void HandleGameExit()
    {
        string key = "escape";

        // Starts the timer from when the key is pressed
        if (Input.GetKeyDown(key))
        {
            startTime = Time.time;
            timer = startTime;
        }
 
        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey(key) && held == false)
        {
            timer += Time.deltaTime;
 
            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (timer > (startTime + holdTime))
            {
                held = true;
                EscapeButtonHeld();
            }
        }
 
        // For single effects. Remove if not needed
        if (Input.GetKeyUp(key))
        {
            held = false;
        }
    
    }

    // Method called after held for required time
    void EscapeButtonHeld()
    {
        Debug.Log("held for " + holdTime + " seconds");
        Application.Quit();
    }
}
