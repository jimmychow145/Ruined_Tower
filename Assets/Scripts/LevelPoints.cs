using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPoints : MonoBehaviour
{
    private Object[] Res;
    private Object newLevel;


    public GameObject scorescript;
    public GameObject hitpoint;
    // Start is called before the first frame update
    void Start()
    {
        Res = Resources.LoadAll("Prefabs");
        newLevel = Res[Random.Range(0, Res.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == "Player" && hitpoint.GetComponent<HealthScript>().getHealth() > 0)
        {
            scorescript.GetComponent<ScoreScript>().addScore(1);

            if(scorescript.GetComponent<ScoreScript>().getScore() % 3 == 1)
            {
                Instantiate(newLevel, new Vector3(2f, this.transform.position.y + 14.7f, 0), Quaternion.identity);
                
            }
            
            
            Destroy(gameObject);
        }
    }
}
