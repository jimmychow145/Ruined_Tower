using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowText : MonoBehaviour
{
    public Text timeText;
    public float currentNumber = 0;
    public float random_R;
    public float random_G;
    public float random_B;
    public float R_multiplier = 1;
    public float G_multiplier = 1;
    public float B_multiplier = 1;



    void Start()
    {
        timeText = GetComponent<Text>();
        random_R = Random.Range(0f, 1f);
        random_G = Random.Range(0f, 1f);
        random_B = Random.Range(0f, 1f);
    }

    void Update()
    {
        
        random_R += (Time.deltaTime / 3)* R_multiplier;
        random_G += Time.deltaTime / 3 * G_multiplier;
        random_B += Time.deltaTime / 3 * B_multiplier;
        timeText.color = new Color(random_R, random_G, random_B, 1.0f);
        if(random_R >= 1)
        {
            R_multiplier *= -1;
        }
        if (random_R <= 0)
        {
            R_multiplier *= -1;
        }
        if (random_G >= 1)
        {
            G_multiplier *= -1;
        }
        if (random_G <= 0)
        {
            G_multiplier *= -1;
        }
        if (random_B >= 1)
        {
            B_multiplier *= -1;
        }
        if (random_B <= 0)
        {
            B_multiplier *= -1;
        }

    }
}
