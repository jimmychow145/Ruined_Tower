using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player.transform.localScale.x <= 0)
        {
            speed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(speed * Time.deltaTime ,0f,0f);
        if(transform.position.x >= 10 || transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
