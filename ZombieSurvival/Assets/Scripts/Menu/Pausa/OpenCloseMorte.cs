using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMorte : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] PlayerHealth playerHealth;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenTelaMorte();
    }

    void OpenTelaMorte()
    {
        if (!PlayerLives())
        {
            gameObject.SetActive(true);
        }
    }

    bool PlayerLives()
    {
        return (playerHealth.playerCurrentHealth > 0);
    }
}
