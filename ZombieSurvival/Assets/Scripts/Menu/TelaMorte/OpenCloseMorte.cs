using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMorte : MonoBehaviour
{
    [SerializeField] GameObject gameObjectt;
    [SerializeField] PlayerHealth playerHealth;
    void Start()
    {
        gameObjectt.SetActive(false);
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
            gameObjectt.SetActive(true);
        }
    }

    bool PlayerLives()
    {
        return (playerHealth.playerCurrentHealth > 0);
    }
}
