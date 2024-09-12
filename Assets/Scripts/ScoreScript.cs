using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoretext;
    public static int score = 0;
    void Start()
    {
        
        scoretext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Your score: " + score.ToString();
        
    }

    public void addScore(int target)
    {
        score += target;

    }
    public int getScore()
    {
        return score;
    }
    public void resetScore()
    {
        score = 0;
    }
    
}
