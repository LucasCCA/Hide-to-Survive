using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaTransform : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] RectTransform stamina;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stamina.position = player.position + offset;
    }
}
