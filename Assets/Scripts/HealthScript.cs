using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Schepens.UtilScripts;

public class HealthScript : MonoBehaviour
{
    public Text healthText;
    public static int health = 3;
    public HighScoreHandler hsHandler = new HighScoreHandler();
    public ScoreScript scoreScript;

    
    public GameObject sceneChanger;

    void Start()
    {
        health = 3;
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Hitpoints: " + health;
        
        
    }

    public void addHealth(int target)
    {
        health++;

    }
    public void minusHealth(int target)
    {

        health-= target;
        checkHealth();

    }
    public int getHealth()
    {
        return health;
    }
    public void resetHealth()
    {
        Debug.Log("Health Reset");
        health = 3;
    }
    public void checkHealth()
    {
        /*if(health <= 0)
        {
            //yield return new WaitForSeconds(5);
            
            Debug.Log("Scene Changed ||||||||||||||||||||||");
            sceneChanger.GetComponent<SceneChanger>().ChangeScene("End Scene");
            Debug.Log("added score");
        }*/
    }
    
    

}
