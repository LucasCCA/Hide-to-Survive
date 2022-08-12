using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    public Transform player;
    public Transform hidingSpot;

    Transform tutorialButton;

    void Start()
    {
        tutorialButton = transform.GetChild(0);
    }

    void Update()
    {
        Unhide();
    }

    public void Hide()
    {
        player.position = hidingSpot.position;
        player.gameObject.SetActive(false);

        tutorialButton.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Unhide()
    {
        if (player.gameObject.activeSelf == false)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                player.gameObject.SetActive(true);

                tutorialButton.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
