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
        player.position = hidingSpot.position;
        player.gameObject.SetActive(false);
    }

    public void Unhide()
    {
        if (player.gameObject.activeSelf == false)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                player.gameObject.SetActive(true);
            }
        }
    }
}
