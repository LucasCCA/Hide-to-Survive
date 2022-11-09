using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasePlayerSpeed : MonoBehaviour
{
    private void Start()
    {
        this.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().speed = 2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().speed = 3f;
        }
    }
}
