using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField] LayerMask playformLayerMask;
    public float moveSpeed = 5f;
    public float distanceGround;
    public int speed = 1;
    public float powerTime = 10.0f;
    public float yAxisDistance;
    public int health = 3;
    private bool Fast = false;
    public float jumpHeight = 10;
    public int incSpeed = 2;
    public Text healthText;
    
    // Use this for initialization
    void Start()
    {
        distanceGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        yAxisDistance = GetComponent<Transform>().position.y;
        Debug.Log(yAxisDistance);
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime*speed;
        

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if(Fast == true)
        {
            PowerUp();
        }
    }

    bool IsGrounded()
    {
        Vector2 centerOfPlayer = GetComponent<BoxCollider2D>().bounds.center;
        float rayDist = distanceGround + 0.5f;

        RaycastHit2D raycastHit = Physics2D.Raycast(centerOfPlayer, Vector2.down, rayDist, playformLayerMask);
        Debug.Log(raycastHit.collider);
        
        return (raycastHit.collider != null);
    }
       
    
    
     
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Spikes")
        {
            healthText.GetComponent<HealthScript>().minusHealth(1);

            Debug.Log("hit");
            
            if(health <= 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }


        if (collision.gameObject.tag == "Zombie")
        {
            healthText.GetComponent<HealthScript>().minusHealth(1);

            Debug.Log("Hit");
            
            if(health <= 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }


        if (collision.gameObject.tag == "Swift")
        {
            Debug.Log("hit");
            moveSpeed = moveSpeed + incSpeed;
            Destroy(collision.gameObject);
            Fast = true;
            
        }

        if (collision.gameObject.tag == "Health")
        {
            Debug.Log("hit");

            healthText.GetComponent<HealthScript>().addHealth(1);

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Stuck")
        {

            Debug.Log("hit");
            moveSpeed = 0.01f;
            
        }

    }

    void PowerUp()
    {
        
        
        if(powerTime > 0f)
        {
            powerTime = powerTime - Time.deltaTime;
            Debug.Log("tic");
        }
        if(powerTime <= 0.0f)
        {
            moveSpeed = moveSpeed - incSpeed;
            Debug.Log("YAY");
            Fast = false;
        }
        
    }
    
}


