using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionRange = 1f;

    [SerializeField] LayerMask interactionLayers;

    void Update()
    {
        Interact();
    }

    void Interact()
    {
        Collider2D interactable = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayers);

        if(interactable != null)
        {
            Transform botao = interactable.transform.GetChild(0);
            botao.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if(Input.GetButtonDown("Fire3"))
            {
                if(interactable.CompareTag("HidingSpot"))
                { 
                    interactable.GetComponent<HidingSystem>().Hide();
                }
                else if(interactable.CompareTag("Enemy"))
                {
                    //mata o inimigo
                }
            }
        }
        else
        {
            DisableButton();
        }
    }

    void DisableButton()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject button in buttons)
        {
            button.GetComponent<SpriteRenderer>().enabled = false;
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
