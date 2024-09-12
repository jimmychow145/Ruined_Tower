using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movement = 5f;
    public int health = 3;
    public float direction = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * movement;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(movement, 0f), ForceMode2D.Force);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            movement *= -1;
            direction *= -1f;
            transform.localScale = new Vector3(direction, 0.3f, 1f);
        }

        if(col.gameObject.tag == "Spikes")
        {
            movement *= -1;
            direction *= -1f;
            transform.localScale = new Vector3(direction, 0.3f, 1f);
        }
        if (col.gameObject.tag == "Zombie")
        {
            movement *= -1;
            direction *= -1f;
            transform.localScale = new Vector3(direction, 0.3f, 1f);
        }
        if (col.gameObject.tag == "Player")
        {
            movement *= -1;
            direction *= -1f;
            transform.localScale = new Vector3(direction, 0.3f, 1f);
        }
    }

    public void minusHealth(int target)
    {
        health -= target;

    }
}
