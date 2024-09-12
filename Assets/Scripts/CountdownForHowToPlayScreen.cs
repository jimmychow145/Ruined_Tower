using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CountdownForHowToPlayScreen : MonoBehaviour
{
    public Text timeText;
    public float time = 5.0f;
    void Start()
    {

        timeText = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Press Fire to Start! " + "(" + time.ToString("F0") + ")";
        time -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<SceneChanger>().ChangeScene("GameScene");
            resetTime();
        }
        if (time <= 0)
        {
            this.GetComponent<SceneChanger>().ChangeScene("GameScene");
            resetTime();
            
        }
    }


    public void resetTime()
    {
        time = 5.0f;
    }

}
