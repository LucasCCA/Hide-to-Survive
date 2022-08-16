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
        Vector3 hidingPos = new Vector3(hidingSpot.position.x, player.position.y, player.position.z);
        player.position = hidingPos;

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
