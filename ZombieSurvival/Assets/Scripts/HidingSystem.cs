using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    public Transform player;
    public Transform hidingSpot;

    void Update()
    {
        Unhide();
    }

    public void Hide()
    {
        Vector2 hidingPos = new Vector2(hidingSpot.position.x, player.position.y);
        player.position = hidingPos;

        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<InteractionSystem>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Unhide()
    {
        if (player.GetComponent<SpriteRenderer>().enabled == false && player.position.x == hidingSpot.position.x)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<PlayerMovement>().enabled = true;
                player.GetComponent<InteractionSystem>().enabled = true;
                player.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
