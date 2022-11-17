using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    PlayerMovement pm;

    [SerializeField] GameObject staminaBar;

    [SerializeField] Image staminaFill;

    private float maxStamina = 100;
    public float currentStamina;

    public float decreaseValue = 15f;
    public float regenValue = 150f;
   
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        currentStamina = maxStamina;
    }

    void Update()
    {
        staminaFill.fillAmount = currentStamina / maxStamina;
        DecreaseStamina();
        EnableStaminaBar();
    }

    void DecreaseStamina()
    {
        if(Input.GetButton("Jump") && Input.GetButton("Horizontal") && pm.enabled == true)
        {
            if (currentStamina > 0)
            {
                currentStamina -= decreaseValue * Time.deltaTime;
            }    
        }
        else if (Input.GetButtonUp("Jump") || Input.GetButtonUp("Horizontal"))
        {
            StartCoroutine(RegenStamina());
        }
    }

    void EnableStaminaBar()
    {
        if (currentStamina < maxStamina)
        {
            staminaBar.GetComponent<Image>().enabled = true;
            staminaBar.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        else
        {
            staminaBar.GetComponent<Image>().enabled = false;
            staminaBar.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += regenValue * Time.deltaTime;
            if (Input.GetButton("Jump") && Input.GetButton("Horizontal") && pm.enabled == true)
                break;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
