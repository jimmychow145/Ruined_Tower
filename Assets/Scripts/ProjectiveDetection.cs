using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectiveDetection : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "playerLaser")
        {
            Debug.Log("Hit");
            scoretext.GetComponent<ScoreScript>().addScore(1);
            gameObject.GetComponent<ZombieMovement>().minusHealth(1);
            Destroy(col.gameObject);
        }
        
    }


}
