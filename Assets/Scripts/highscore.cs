using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Schepens.UtilScripts;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    private bool held = false;
    public float holdTime = 3.0f; // how long you need to hold to trigger the effect

    private float startTime = 0f;
    private float timer = 0f;


    // Start is called before the first frame update
    public HighScoreHandler hsHandler = new HighScoreHandler();
    public Transform entryContainer;
    public Transform entryTemplate;
    public float templateHeight = 20f;
    public List<HighScore> scoreList;
    public int score;
    public GameObject scoreText;
    public GameObject initial;
    public string currentInitial;

    public void Awake()
    {
        Debug.Log("start handler");
        hsHandler.ReadFromFile();
        score = scoreText.GetComponent<ScoreScript>().getScore();
        hsHandler.AddScore(initial.GetComponent<InitialScript>().getInitial(), score);
        scoreList = hsHandler.getScoreList();


        //entryTemplate.gameObject.SetActive(false);

        entryTemplate.gameObject.SetActive(false);
        for (int i = 0; i < scoreList.Count; i++)
        {
            Debug.Log("Created" + i);
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            switch (i)
            {
                default:
                    entryTransform.Find("posText").GetComponent<Text>().text = (i + 1).ToString() + "TH";

                    break;

                case 0:
                    entryTransform.Find("posText").GetComponent<Text>().text = (i + 1).ToString() + "ST";
                    Debug.Log("1st");
                    break;
                case 1: entryTransform.Find("posText").GetComponent<Text>().text = (i + 1).ToString() + "ND"; break;
                case 2: entryTransform.Find("posText").GetComponent<Text>().text = (i + 1).ToString() + "RD"; break;

            }

            entryTransform.Find("scoreText").GetComponent<Text>().text = scoreList[i].score.ToString();
            entryTransform.Find("nameText").GetComponent<Text>().text = scoreList[i].initials.ToUpper();
        }
    }



    void Update()
    {
        HandleGameExit();
    }



    public void Start()
    {
        Debug.Log("start handler");





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
