using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    public GameObject laser;
    public float time = 5;

    private float radius;
    private float speed;
    public float xSpawn;
    public float ySpawn;
    public float zSpawn;
    public float extend;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        radius = Random.Range(0.5f, 1.5f);
        speed = Random.Range(1f,5f);

        xSpawn = transform.position.x ;
        ySpawn = transform.position.y;
        zSpawn = transform.position.z;
        extend = GetComponent<BoxCollider2D>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        xSpawn = transform.position.x;
        ySpawn = transform.position.y;
        zSpawn = transform.position.z;
        

        //transform.LookAt(player);
        //transform.RotateAround(new Vector3(Random.Range(xSpawn+0.5f, xSpawn+1.5f), Random.Range(ySpawn+0.5f, ySpawn+1.5f), 0), Vector3.forward, speed*Time.deltaTime);
    }

    public void fireLaser()
    {
        Instantiate(laser, new Vector3(xSpawn,ySpawn,zSpawn), transform.rotation);
    }
}
