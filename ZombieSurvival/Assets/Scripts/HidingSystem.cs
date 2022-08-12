using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    public Transform player;
    public Transform hidingSpot;

    Transform tutorialButton;
    PlayerMovement pm;
    InteractionSystem interactionSystem;
    BoxCollider2D playerCollider;

    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        interactionSystem = player.GetComponent<InteractionSystem>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        tutorialButton = transform.GetChild(0);
    }

    void Update()
    {
        Unhide();
    }

    public void Hide()
    {
        player.position = hidingSpot.position;
        player.GetComponent<SpriteRenderer>().enabled = false;

        pm.enabled = false;
        interactionSystem.enabled = false;
        playerCollider.enabled = false;
        tutorialButton.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Unhide()
    {
        if (interactionSystem.enabled == false)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                player.GetComponent<SpriteRenderer>().enabled = true;

                tutorialButton.GetComponent<SpriteRenderer>().enabled = false;
                pm.enabled = true;
                interactionSystem.enabled = true;
                playerCollider.enabled = true;
            }
        }
    }
}
