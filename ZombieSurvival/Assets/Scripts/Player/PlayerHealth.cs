using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerCurrentHealth;
    private float playerMaxHealth = 100f;
    [SerializeField] private Image barraDeVida;
    
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        KillPlayer();
        LifeBar();
    }

    private void LifeBar()
    {
        barraDeVida.fillAmount = playerCurrentHealth/playerMaxHealth;
    }

    public void KillPlayer()
    {
        if(playerCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}