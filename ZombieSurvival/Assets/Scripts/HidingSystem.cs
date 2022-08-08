using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    public Transform player;
    public Transform hidingSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        player.position = hidingSpot.position;
        player.GetComponent<SpriteRenderer>().enabled = false;

        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.enabled = false;
    }
}
