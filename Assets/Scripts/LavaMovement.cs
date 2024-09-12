using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LavaMovement : MonoBehaviour
{
    public float lavaRate = 0.5f;
    public GameObject scorescript;
    public float time = 0f;
    public float nextLavaIncreaseTime = 10f;
    public float currentScore;
    public bool playing = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        time += Time.deltaTime;
        currentScore = scorescript.GetComponent<ScoreScript>().getScore();
        transform.position += new Vector3(0f, lavaRate, 0f) * Time.deltaTime;

        if(time >= nextLavaIncreaseTime && lavaRate <=3)
        {
            lavaRate += 0.2f;
            Debug.Log("lava faster");
            nextLavaIncreaseTime += 10f;
        }
        
    }
    

    void OnCollisionExit2D(Collision2D col)
    {

        
        if (col.gameObject.tag == "Player") 
        {
            
            
        }
        if(col.gameObject.tag == "Zombie")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Spider Web")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Spikes")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Wall")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Ground")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Swift")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Health")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "stickyFloor")
        {
            Destroy(col.gameObject);
        }


    }
}
