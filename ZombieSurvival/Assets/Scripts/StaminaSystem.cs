using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] Slider staminaSlider;

    private float maxStamina = 100;
    public float currentStamina;

    public float decreaseValue = 15f;
    public float regenValue = 30f;
   
    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
    }

    void Update()
    {
        staminaSlider.value = currentStamina;
        DecreaseStamina();
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

    IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += regenValue * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
