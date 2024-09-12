using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript_Classic : MonoBehaviour
{
    public GameObject sceneChanger;
    public AudioSource[] allAudioSources;

    public float holdTime = 3.0f; // how long you need to hold to trigger the effect
 
    private float startTime = 0f;
    private float timer = 0f;
    public float oldMoveSpeed;
    public float MoveSpeed = 1;
    public float jumpHeight = 3;
    public float jumpSpeed = 1;
    public float fallSpeed = 0.5f;
    public Animator animator;
    public AudioSource powerUpAudio;
    public AudioSource fireAudio;
    public AudioSource TakingDamageAudio;
    public AudioSource GameoverAudio;
    public AudioSource JumpAudio;
    private Vector2 newDirection;
    public bool isGameoverSoundPlaying = false;


    [SerializeField] LayerMask playformLayerMask;   
    public float distanceGround;
    public float speedPowerTime = 10.0f;
    public float spiderWebPowerTime = 0.3f;
    public float yAxisDistance;
    public bool Fast = false;
    public bool trapped = false;
    public float incSpeed = 2.0f;
    public bool pleaseJump = false;
    public bool movingLeft = false;
    public bool movingRight = false;
    public StaminaBar staminaController;
    private float KnockbackForce = 100f;
    private bool isHit = false;

    public Text healthText;

 
    // Use if you only want to call the method once after holding for the required time
    private bool held = false;
    
    void Start()
    {
        oldMoveSpeed = MoveSpeed;
        staminaController = GetComponent<StaminaBar>();
        animator = gameObject.GetComponent<Animator>();
        powerUpAudio = GetComponent<AudioSource>();
    }
    public void Update()
    {
        HandleGameExit();
        HandleMameInputs();
        Debug.Log(IsGrounded());
        
        //MoveObject(newDirection);

        newDirection = new Vector2(0,-fallSpeed);

        if(Fast == true)
        {
            speedPowerUp();
        }   
        if(trapped == true)
        {
            spiderWebTrap();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        

        if(healthText.GetComponent<HealthScript>().getHealth() <= 0)
        {
           
            animator.SetBool("Death", true);
            StartCoroutine(ExecuteAfterTime(2f));

            //animator.SetBool("Death", false);
        }
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        sceneChanger.GetComponent<SceneChanger>().ChangeScene("InitialScene");

    }

    

    void FixedUpdate()
    {
        if (pleaseJump == true)
        {
            animator.SetBool("Jump", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            pleaseJump = false;     
        }
        if(movingLeft == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-MoveSpeed, 0f), ForceMode2D.Force);
            movingLeft = false;
        }
        if(movingRight == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(MoveSpeed, 0f), ForceMode2D.Force);
            movingRight = false;
        }
        if(isHit)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f),  ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(KnockbackForce, 0f),  ForceMode2D.Impulse);
            Debug.Log("knocked back");
            animator.SetBool("Hit", true);
            isHit = false;
        }
    }

    public void SetRunSpeed(float speed)
    {
        MoveSpeed = speed;
    }

    // This will check to see if the Escape key has been held down for holdTime time
    private void HandleGameExit()
    {
        string key = "escape";

        // Starts the timer from when the key is pressed
        if (Input.GetKeyDown(key))
        {
            startTime = Time.time;
            timer = startTime;
        }
 
        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey(key) && held == false)
        {
            timer += Time.deltaTime;
 
            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (timer > (startTime + holdTime))
            {
                held = true;
                EscapeButtonHeld();
            }
        }
 
        // For single effects. Remove if not needed
        if (Input.GetKeyUp(key))
        {
            held = false;
        }
    
    }
    
    // Method called after held for required time
    void EscapeButtonHeld()
    {
        Debug.Log("held for " + holdTime + " seconds");
        Application.Quit();
    }

    private void HandleMameInputs()
    {

        ///////////////////////////////////////////
        //  Default Keymap	
        ///////////////////////////////////////////
        /* Main Keys	
        5,6,7,8	   Insert coin	
        1,2,3,4	   Players 1 - 4 start buttons	
        
        Arrow Keys	Controller (Player 1)	
        
        Left Ctrl	Fire 1 (Player 1)	
        Left Alt	Fire 2 (Player 1)	
        Space	    Fire 3 (Player 1)	
        Left Shift	Fire 4 (Player 1)	
        Z	        Fire 5 (Player 1)	
        X           Fire 6(Player 1)	
        
        R,F,G,D	Controller (Player 2)	
        A         Fire 1 (Player 2)	
        S         Fire 2 (Player 2)	
        Q         Fire 3 (Player 2)	
        W         Fire 4 (Player 2)	
        E         Fire 5 (Player 2)	Not set by default
        T         Fire 6 (Player 2)	Not Set By Default	
        
        Playchoice 10 Additional Keys	
        5         Adds Time	
        0         Select Game	
        1         Toggles 1 or 2 Player Mode	
        2         Start Game
        */


        /////////////////////////////////////////////
        // Control Keys
        /////////////////////////////////////////////

        


        /////////////////////////////////////////////
        // Player 1 Movements
        /////////////////////////////////////////////
        if(Input.GetKey(KeyCode.LeftArrow) && healthText.GetComponent<HealthScript>().getHealth() >= 1)
        {
            movingLeft = true;
            transform.localScale = new Vector3(-3f, 3f, 0.5f);
            KnockbackForce = 30f;
            animator.SetBool("Run", true);
         
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && healthText.GetComponent<HealthScript>().getHealth() >= 1)
        {
            movingRight = true;
            transform.localScale = new Vector3(3f, 3f, 0.5f);
            KnockbackForce = -30f;
            animator.SetBool("Run", true);
        }
        if(!Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow)))
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && IsGrounded()&& (trapped == false))
        {
            pleaseJump = true;
            JumpAudio.Play();
        }


       

        /////////////////////////////////////
        // Player 1 Actions
        /////////////////////////////////////
        // Left Ctrl   Fire 1(Player 1)
        if (Input.GetKeyDown(KeyCode.Space) && healthText.GetComponent<HealthScript>().getHealth() >= 1)
        {
            fireAudio.Play();
            gameObject.GetComponent<FireLaser>().fireLaser();
            

           
            animator.SetBool("Lazer", true);
        }
        if(!Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Lazer", false);
        }

        // Left Alt    Fire 2(Player 1)
        if (Input.GetKey(KeyCode.LeftAlt) && !Fast && healthText.GetComponent<HealthScript>().getHealth() >= 1)
        {
            if (staminaController.playerStamina > 0 && (movingLeft || movingRight))
            {
                staminaController.weAreSprinting = true;
                staminaController.Sprinting();
                animator.SetBool("Sprint", true);
            }
            if (staminaController.playerStamina <= 0)
            {
                staminaController.weAreSprinting = false;
                
            }
   
        }
        if (!Input.GetKey(KeyCode.LeftAlt)||(!movingLeft && !movingRight))
        {
            staminaController.weAreSprinting = false;
            animator.SetBool("Sprint", false);
            

        }
        


    }


    private void MoveObject(Vector2 direction)
    {
        
        float dx = direction.x;
        float dy = direction.y;

        Vector3 pos = gameObject.transform.position;
        pos.x += dx * MoveSpeed * Time.deltaTime;
        pos.y += dy * MoveSpeed * Time.deltaTime;
        gameObject.transform.position = pos;

    }

 void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Spikes")
        {         
            isHit = true;
            healthText.GetComponent<HealthScript>().minusHealth(1);
            TakingDamageAudio.Play();
        }


        if (collision.gameObject.tag == "Lava")
        {
            //effectively sets the health to 0
            healthText.GetComponent<HealthScript>().minusHealth(healthText.GetComponent<HealthScript>().getHealth());
            

            if (isGameoverSoundPlaying == false)
            {
                stopAllAudio();
                Debug.Log("stopped all audio");
                GameoverAudio.Play();
                Debug.Log("playdeadsound");
                isGameoverSoundPlaying = true;


            }



        }

        if (collision.gameObject.tag == "Zombie")
        {
            isHit = true;
            healthText.GetComponent<HealthScript>().minusHealth(1);
            TakingDamageAudio.Play();

        }
        if (collision.gameObject.tag == "Spider Web")
        {
            trapped = true;
            Destroy(collision.gameObject);
            animator.SetBool("Trapped", true);
            animator.SetBool("Run", false);
            TakingDamageAudio.Play();

        }

        if (collision.gameObject.tag == "stickyFloor")
        {
            SetRunSpeed(150);
            staminaController.normalSpeed /= 2;
        }
        if (collision.gameObject.tag == "Ground" && IsGrounded())
        {
            Debug.Log("hit floor");
            animator.SetBool("Jump", false);
            animator.SetBool("Hit", false);
        }

    }
 
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stickyFloor")
        {
            SetRunSpeed(300);
            staminaController.normalSpeed *= 2;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Swift")
        {
            powerUpAudio.Play();
            Debug.Log("hit");
            Destroy(collision.gameObject);
            Fast = true;
        }

        if (collision.gameObject.tag == "Health")
        {
            powerUpAudio.Play();
            healthText.GetComponent<HealthScript>().addHealth(1);
            Destroy(collision.gameObject);

            
        }
    }

    void speedPowerUp()
    {
        if(speedPowerTime > 0f)
        {
            speedPowerTime -= Time.deltaTime;
            staminaController.weAreSprinting = true;
            Debug.Log("tic");
        }
        if(speedPowerTime <= 0.0f)
        {
            MoveSpeed = MoveSpeed - incSpeed;
            Debug.Log("YAY");
            Fast = false;
            speedPowerTime = 10.0f;
        }
    }

    void spiderWebTrap()
    {
        oldMoveSpeed = MoveSpeed;
        MoveSpeed = 0.0f;
        if (spiderWebPowerTime > 0f)
        {
            spiderWebPowerTime = spiderWebPowerTime - Time.deltaTime;
            Debug.Log("tic");
        }
        if (spiderWebPowerTime <= 0.0f)
        {
            MoveSpeed = oldMoveSpeed;
            spiderWebPowerTime = 0.3f;
            trapped = false;
            animator.SetBool("Trapped", false);
        }
    }
        
    bool IsGrounded()
    {
        Vector2 centerOfPlayer = GetComponent<BoxCollider2D>().bounds.center;

        Vector2 rightofPlayer = centerOfPlayer + new Vector2(GetComponent<BoxCollider2D>().bounds.extents.x-0.05f, 0f);
        Vector2 leftofPlayer = centerOfPlayer - new Vector2(GetComponent<BoxCollider2D>().bounds.extents.x - 0.05f, 0f);

        float rayDist = distanceGround;

        RaycastHit2D raycastHit = Physics2D.Raycast(centerOfPlayer, Vector2.down, rayDist, playformLayerMask);
        RaycastHit2D raycastHitLeft = Physics2D.Raycast(leftofPlayer, Vector2.down, rayDist, playformLayerMask);
        RaycastHit2D raycastHitRight = Physics2D.Raycast(rightofPlayer, Vector2.down, rayDist, playformLayerMask);

        Debug.DrawRay(centerOfPlayer, Vector2.down * rayDist,Color.green);
        Debug.DrawRay(leftofPlayer, Vector2.down * rayDist, Color.green);
        Debug.DrawRay(rightofPlayer, Vector2.down * rayDist, Color.green);

        return (raycastHit.collider != null || raycastHitLeft.collider != null || raycastHitRight.collider != null);
    }

    void changeScene()
    {
        
        sceneChanger.GetComponent<SceneChanger>().ChangeScene("InitialScene");
    }

    void stopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    
  
}
