using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float playerStamina = 100.0f;
    public float maxStamina = 100.0f;
    
    public bool hasRegenerated = true;
    public bool weAreSprinting = false;
    public float staminaDrain = 0.5f;
    public float staminaRegen = 0.5f;

    public float SprintingSpeed = 8.0f ;
    public float normalSpeed = 300.0f;
    public Image staminaProgressUI = null;
    public CanvasGroup sliderCanvasGroup = null;

    public PlayerScript_Classic playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerScript_Classic>();
    }


    void Update()
    {
        if (!weAreSprinting && (playerController.trapped == false))
        {
            playerController.SetRunSpeed(normalSpeed);
            

            if (playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);
                if (playerStamina >= maxStamina)
                {
                    
                    sliderCanvasGroup.alpha = 0;
                    
                }
            }
        }
        if (playerController.Fast)
        {
            playerController.SetRunSpeed(SprintingSpeed);
        }
        
    }
    public void Sprinting()
    {
        playerController.SetRunSpeed(SprintingSpeed);
            weAreSprinting = true;
            playerStamina -= staminaDrain* Time.deltaTime;
            UpdateStamina(1);
            if (playerStamina <= 0)
            {
                
                
                sliderCanvasGroup.alpha = 0;
            }
            
        
    }

    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;
        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
