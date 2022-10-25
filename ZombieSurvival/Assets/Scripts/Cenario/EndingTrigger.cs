using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject staminaBar;
    [SerializeField] GameObject playerHealth;
    [SerializeField] GameObject playerHead;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wall.SetActive(true);
            staminaBar.SetActive(false);
            playerHealth.SetActive(false);
            playerHead.SetActive(false);
        }
    }
}
