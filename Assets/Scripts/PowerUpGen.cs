using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGen : MonoBehaviour
{
    private Object[] powerupList;
    private Object powerup;
    public int powerupFreq = 50;
    // Start is called before the first frame update
    void Start()
    {
        /*powerupList = Resources.LoadAll("PowerUps");
        powerup = powerupList[Random.Range(0, powerupList.Length)];
        if(1 > Random.Range(0, powerupFreq))
        {
            Instantiate(powerup, this.transform.position + new Vector3(0,1.5f,0), Quaternion.identity, this.transform); 
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}