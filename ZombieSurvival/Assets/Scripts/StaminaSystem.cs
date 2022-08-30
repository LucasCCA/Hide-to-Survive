using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] GameObject staminaBar;

    [SerializeField] Image staminaFill;

    private float maxStamina = 100;
    public float currentStamina;

    public float decreaseValue = 15f;
    public float regenValue = 150f;
   
    void Start()
    {
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
        if(Input.GetButton("Jump") && Input.GetButton("Horizontal"))
        {
            if (currentStamina > 0)
            {
                currentStamina -= decreaseValue * Time.deltaTime;
            }    
        }
        else if (Input.GetButtonUp("Jump"))
        {
            StartCoroutine(RegenStamina());
        }
    }

    void EnableStaminaBar()
    {
        if (currentStamina < maxStamina)
        {
            staminaBar.SetActive(true);
        }
        else
        {
            staminaBar.SetActive(false);
        }
    }

    IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += regenValue * Time.deltaTime;
            if (Input.GetButton("Jump") && Input.GetButton("Horizontal"))
                break;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
