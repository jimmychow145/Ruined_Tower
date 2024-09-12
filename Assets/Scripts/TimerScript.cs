using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour
{
    public Text timeText;
    public GameObject scoreText;
    public GameObject healthText;
    public GameObject player;
    public float time = 10.0f;
    void Start()
    {

        timeText = GetComponent<Text>();
        

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Press Player 1 to Play again! " + "(" + time.ToString("F0") + ")";
        time -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Alpha1) && SceneManager.GetActiveScene().name == "End Scene")
        {
            this.GetComponent<SceneChanger>().ChangeScene("GameScene");
            scoreText.GetComponent<ScoreScript>().resetScore();
            healthText.GetComponent<HealthScript>().resetHealth();
            Debug.Log("gameovermusicfalse");
            resetTime();
        }
        if (time <= 0)
        {
            this.GetComponent<SceneChanger>().ChangeScene("Start Scene");
            resetTime();
            scoreText.GetComponent<ScoreScript>().resetScore();
            healthText.GetComponent<HealthScript>().resetHealth();
        }
    }

    
    public void resetTime()
    {
        time = 10.0f;
    }

}
