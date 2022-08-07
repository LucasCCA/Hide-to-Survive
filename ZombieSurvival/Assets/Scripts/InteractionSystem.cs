using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionRange = 1f;

    [SerializeField] LayerMask interactionLayers;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        Collider2D interactable = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayers);

        if(interactable != null)
        {
            //Algo acontece
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(interactionPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }
}
