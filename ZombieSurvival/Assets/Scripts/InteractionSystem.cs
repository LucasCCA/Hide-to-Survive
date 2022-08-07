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
        DisableButton();
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
            Transform botao = interactable.transform.GetChild(0);
            botao.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if(Input.GetButtonDown("Fire3"))
            {
                //Interacao acontece
                botao.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                interactable.GetComponent<BoxCollider2D>().enabled = false;
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
