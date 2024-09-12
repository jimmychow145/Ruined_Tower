using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    
    


    public float powerTime = 0.0f;
    

    
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerScript_Classic>().MoveSpeed = 400f;
            powerTime = 10.0f;
        }
        if(powerTime > 0f)
        {
            powerTime -= Time.deltaTime;
        }
        if(powerTime <= 0.0f)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerScript_Classic>().MoveSpeed = 300f;
            powerTime = 10.0f;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
